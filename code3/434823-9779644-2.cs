    class BorderFinder {
        int stride = 0;
        int[] visited = null;
        byte[] bytes = null;
        Size size = Size.Empty;
        bool outside = false;
        public Point[] Find(Bitmap bmp, bool outside = true) {
            this.outside = outside;
            List<Point> border = new List<Point>();
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            stride = bmpdata.Stride;
            bytes = new byte[bmp.Width * bmp.Height * 4];
            size = bmp.Size;
            Marshal.Copy(bmpdata.Scan0, bytes, 0, bytes.Length);
            Point startpos = getFirstPoint(bytes);
            visited = new int[bmp.Size.Width * bmp.Size.Height];
            border.Add(startpos);
            Point current = getNextPoint(startpos);
            border.Add(current);
            visited[current.Y * bmp.Width + current.X]++;
            while (!current.Equals(startpos)) {
                var pos = current;
                if (visited[current.Y * bmp.Width + current.X] < 2) {
                    current = getNextPoint(pos);
                    visited[pos.Y * bmp.Width + pos.X]++;
                    if (current == Point.Empty)
                        current = getNextPointBackwards(pos);
                } else {
                    current = getNextPointBackwards(pos);
                }
                if (current.X == 235 && current.Y == 41)
                    Console.WriteLine("aa");
                visited[current.Y * bmp.Width + current.X]++;
                border.Add(current);
            }
            bmp.UnlockBits(bmpdata);
            return border.ToArray();
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
            return ((bytes[y * stride + x * 4 + 3] == 0) == outside);
        }
        private bool HasNeighbor(int x, int y) {
            if (y > 0) {
                if ((bytes[(y - 1) * stride + x * 4 + 3] != 0) == outside) {
                    return true;
                }
            } else if (!ValidPoint(x,y)) {
                return true;
            }
            if (x < size.Width - 1) {
                if ((bytes[y * stride + (x + 1) * 4 + 3] != 0) == outside) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            if (y < size.Height - 1) {
                if ((bytes[(y + 1) * stride + x * 4 + 3] != 0) == outside) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            if (x > 0) {
                if ((bytes[y * stride + (x - 1) * 4 + 3] != 0) == outside) {
                    return true;
                }
            } else if (!ValidPoint(x, y)) {
                return true;
            }
            return false;
        }
        private Point getFirstPoint(byte[] bytes) {
            Point startpos = Point.Empty;
            for (int y = 0; y < size.Height; y++) {
                for (int x = 0; x < size.Width; x++) {
                    if (outside) {
                        if (y < size.Height && bytes[(y + 1) * stride + x * 4 + 3] != 0) {
                            startpos = new Point(x, y);
                            return startpos;
                        }
                        if (bytes[y * stride + x * 4 + 3] != 0) {
                            startpos = new Point(x - 1, y);
                            return startpos;
                        }
                    } else {
                        if (bytes[y * stride + x * 4 + 3] != 0) {
                            startpos = new Point(x, y);
                            return startpos;
                        }
                    }
                }
            }
            return startpos;
        }
    }
