    class BorderFinder {
        int stride = 0;
        int[] visited = null;
        byte[] bytes = null;
        PointData borderdata = null;
        Size size = Size.Empty;
        bool outside = false;
        public List<Point[]> Find(Bitmap bmp, bool outside = true) {
            this.outside = outside;
            List<Point> border = new List<Point>();
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            stride = bmpdata.Stride;
            bytes = new byte[bmp.Width * bmp.Height * 4];
            size = bmp.Size;
            Marshal.Copy(bmpdata.Scan0, bytes, 0, bytes.Length);
            // Get all Borderpoint
            borderdata = getBorderData(bytes);
            bmp.UnlockBits(bmpdata);
            List<List<Point>> regions = new List<List<Point>>();
            //Loop until no more borderpoints are available
            while (borderdata.PointCount > 0) {
                List<Point> region = new List<Point>();
                //if valid is false the region doesn't close
                bool valid = true;
                //Find the first borderpoint from where whe start crawling
                Point startpos = getFirstPoint(borderdata);
                //we need this to know if and how often we already visted the point.
                //we somtime have to visit a point a second time because we have to go backward until a unvisted point is found again
                //for example if we go int a narrow 1px hole
                visited = new int[bmp.Size.Width * bmp.Size.Height];
                
                region.Add(startpos);
                //Find the next possible point
                Point current = getNextPoint(startpos);
                region.Add(current);
                visited[current.Y * bmp.Width + current.X]++;
                //May occure with just one transparent pixel without neighbors
                if (current == Point.Empty)
                    valid = false;
                //Loop until the area closed or colsing the area wasn't poosible
                while (!current.Equals(startpos) && valid) {
                    var pos = current;
                    //Check if the area was aready visited
                    if (visited[current.Y * bmp.Width + current.X] < 2) {
                        current = getNextPoint(pos);
                        visited[pos.Y * bmp.Width + pos.X]++;
                        //If no possible point was found, search in reversed direction
                        if (current == Point.Empty)
                            current = getNextPointBackwards(pos);
                    } else { //If point was already visited, search in reversed direction
                        current = getNextPointBackwards(pos);
                    }
                    //No possible point was found. Closing isn't possible
                    if(current == Point.Empty)
                        valid = false;
                    visited[current.Y * bmp.Width + current.X]++;
                    region.Add(current);
                }
                //Remove point from source borderdata
                foreach (var p in region) {
                    borderdata.SetPoint(p.Y * bmp.Width + p.X, false);
                }
                //Add region if closing was possible
                if(valid)
                    regions.Add(region);
            }
            //Checks if Region goes the same way back and trims it in this case
            foreach (var region in regions) {
                int duplicatedpos = -1;
                bool[] duplicatecheck = new bool[size.Width * size.Height];
                int length = region.Count;
                for (int i = 0; i < length; i++) {
                    var p = region[i];
                    if(duplicatecheck[p.Y * size.Width + p.X]){
                        duplicatedpos = i - 1;
                        break;
                    }
                    duplicatecheck[p.Y * size.Width + p.X] = true;
                }
                if (duplicatedpos == -1)
                    continue;
                if (duplicatedpos != ((region.Count - 1) / 2))
                    continue;
                bool reversed = true;
                for (int i = 0; i < duplicatedpos; i++) {
                    if (region[duplicatedpos - i - 1] != region[duplicatedpos + i + 1]) {
                        reversed = false;
                        break;
                    }
                }
                if (!reversed)
                    continue;
                region.RemoveRange(duplicatedpos + 1, region.Count - duplicatedpos - 1);
            }
            List<List<Point>> tempregions = new List<List<Point>>(regions);
            regions.Clear();
            bool connected = true;
            //Connects region if possible
            while (connected) {
                connected = false;
                foreach (var region in tempregions) {
                    int connectionpos = -1;
                    int connectionregion = -1;
                    Point pointstart = region.First();
                    Point pointend = region.Last();
                    for(int ir = 0; ir < regions.Count; ir ++){
                        var otherregion = regions[ir];
                        if (region == otherregion)
                            continue;
                        for (int ip = 0; ip < otherregion.Count; ip ++){
                            var p = otherregion[ip];
                            if ((isConnected(pointstart, p) && isConnected(pointend, p)) ||
                                (isConnected(pointstart, p) && isConnected(pointstart, p))) {
                                    connectionregion = ir;
                                    connectionpos = ip;
                            }
                            if ((isConnected(pointend, p) && isConnected(pointend, p))) {
                                region.Reverse();
                                connectionregion = ir;
                                connectionpos = ip;
                            }
                        }
                    }
                    if (connectionpos == -1) {
                        regions.Add(region);
                    } else {
                        regions[connectionregion].InsertRange(connectionpos, region);
                    }
                }
                tempregions = new List<List<Point>>(regions);
                regions.Clear();
            }
            List<Point[]> returnregions = new List<Point[]>();
            foreach(var region in tempregions)
                returnregions.Add(region.ToArray());
            return returnregions;
        }
        private bool isConnected(Point p0, Point p1) {
            if (p0.X == p1.X && p0.Y - 1 == p1.Y)
                return true;
            if (p0.X + 1 == p1.X && p0.Y - 1 == p1.Y)
                return true;
            if (p0.X + 1 == p1.X && p0.Y == p1.Y)
                return true;
            if (p0.X + 1 == p1.X && p0.Y + 1 == p1.Y)
                return true;
            if (p0.X == p1.X && p0.Y + 1 == p1.Y)
                return true;
            if (p0.X - 1 == p1.X && p0.Y + 1 == p1.Y)
                return true;
            if (p0.X - 1 == p1.X && p0.Y == p1.Y)
                return true;
            if (p0.X - 1 == p1.X && p0.Y - 1 == p1.Y)
                return true;
            return false;
        }
        private Point getNextPoint(Point pos) {
            if (pos.Y > 0) {
                int x = pos.X;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || x == 0 || x == size.Width - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.Y > 0 && pos.X < size.Width - 1) {
                int x = pos.X + 1;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || y == size.Height - 1 || x == size.Width - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.X < size.Width - 1) {
                int x = pos.X + 1;
                int y = pos.Y;
                if ((ValidPoint(x, y) || y == 0 || y == size.Height - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.X < size.Width - 1 && pos.Y < size.Height - 1) {
                int x = pos.X + 1;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || y == size.Height - 1 || x == size.Width - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.Y < size.Height - 1) {
                int x = pos.X;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || x == 0 || x == size.Width - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.Y < size.Height - 1 && pos.X > 0) {
                int x = pos.X - 1;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || x == 0 || y == size.Height - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.X > 0) {
                int x = pos.X - 1;
                int y = pos.Y;
                if ((ValidPoint(x, y) || y == 0 || y == size.Height - 1) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            if (pos.X > 0 && pos.Y > 0) {
                int x = pos.X - 1;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                }
            }
            return Point.Empty;
        }
        private Point getNextPointBackwards(Point pos) {
            Point backpoint = Point.Empty;
            int trys = 0;
            if (pos.X > 0 && pos.Y > 0) {
                int x = pos.X - 1;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.X > 0) {
                int x = pos.X - 1;
                int y = pos.Y;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.Y < size.Height - 1 && pos.X > 0) {
                int x = pos.X - 1;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.Y < size.Height - 1) {
                int x = pos.X;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.X < size.Width - 1 && pos.Y < size.Height - 1) {
                int x = pos.X + 1;
                int y = pos.Y + 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.X < size.Width - 1) {
                int x = pos.X + 1;
                int y = pos.Y;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.Y > 0 && pos.X < size.Width - 1) {
                int x = pos.X + 1;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            if (pos.Y > 0) {
                int x = pos.X;
                int y = pos.Y - 1;
                if ((ValidPoint(x, y) || x == 0 || y == 0) && HasNeighbor(x, y)) {
                    if (visited[y * size.Width + x] == 0) {
                        return new Point(x, y);
                    }
                    if (backpoint == Point.Empty || trys > visited[y * size.Width + x]) {
                        backpoint = new Point(x, y);
                        trys = visited[y * size.Width + x];
                    }
                }
            }
            return backpoint;
        }
        private bool ValidPoint(int x, int y) {
            return (borderdata[y * size.Width + x]);
        }
        private bool HasNeighbor(int x, int y) {
            if (y > 0) {
                if (!borderdata[(y - 1) * size.Width + x]) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            if (x < size.Width - 1) {
                if (!borderdata[y * size.Width + (x + 1)]) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            if (y < size.Height - 1) {
                if (!borderdata[(y + 1) * size.Width + x]) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            if (x > 0) {
                if (!borderdata[y * size.Width + (x - 1)]) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            return false;
        }
        private Point getFirstPoint(PointData data) {
            Point startpos = Point.Empty;
            for (int y = 0; y < size.Height; y++) {
                for (int x = 0; x < size.Width; x++) {
                    if (data[y * size.Width + x]) {
                        startpos = new Point(x, y);
                        return startpos;
                    }
                }
            }
            return startpos;
        }
        private PointData getBorderData(byte[] bytes) {
            PointData isborderpoint = new PointData(size.Height * size.Width);
            bool prevtrans = false;
            bool currenttrans = false;
            for (int y = 0; y < size.Height; y++) {
                prevtrans = false;
                for (int x = 0; x < size.Width; x++) {
                    currenttrans = bytes[y * stride + x * 4 + 3] == 0;
                    if (prevtrans && !currenttrans)
                        isborderpoint.SetPoint(y * size.Width + x - 1, true);
                    if (!prevtrans && currenttrans && x != 0)
                        isborderpoint.SetPoint(y * size.Width + x, true);
                    prevtrans = currenttrans;
                }
            }
            for (int x = 0; x < size.Width; x++) {
                prevtrans = false;
                for (int y = 0; y < size.Height; y++) {
                    currenttrans = bytes[y * stride + x * 4 + 3] == 0;
                    if (prevtrans && !currenttrans)
                        isborderpoint.SetPoint((y - 1) * size.Width + x, true);
                    if (!prevtrans && currenttrans && y != 0)
                        isborderpoint.SetPoint(y * size.Width + x, true);
                    prevtrans = currenttrans;
                }
            }
            return isborderpoint;
        }
    }
    class PointData {
        bool[] points = null;
        int validpoints = 0;
        public PointData(int length) {
            points = new bool[length];
        }
        public int PointCount {
            get {
                return validpoints;
            }
        }
        public void SetPoint(int pos, bool state) {
            if (points[pos] != state) {
                if (state)
                    validpoints++;
                else
                    validpoints--;
            }
            points[pos] = state;
        }
        public bool this[int pos] {
            get {
                return points[pos];
            }
        }
    }
