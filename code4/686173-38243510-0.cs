        public enum ArrangeOrientation : int {
            None,
            Horizonatal,
            Vertical,
            HorizontalGrid,
            VerticalGrid,
            TopLeftGrid,
            TopRightGrid,
            BottomLeftGrid,
            BottomRightGrid
        }
        private void ArrangeButtons(List<Control> controls, List<Control> parents, ArrangeOrientation orientation, double shrinkFactor = 1d) {
            if(controls == null) return;
            if(parents == null) parents = new List<Control>();
            List<Control> childs = new List<Control>();
            Control parent = null;
            foreach(Control ctrl in controls) {
                if(parent == null && !parents.Contains(ctrl.Parent)) {
                    parents.Add(ctrl.Parent);
                    parent = ctrl.Parent;
                }
                if(parent == ctrl.Parent)
                    childs.Add(ctrl);
            }
            if(parent != null && childs.Count > 0) {
                ArrangeControlsToGridLayout(childs, orientation, shrinkFactor);
                ArrangeButtons(controls, parents, orientation, shrinkFactor);
            }
        }
	
        private void ArrangeControlsToGridLayout(List<Control> controls, ArrangeOrientation orientation, double shrinkFactor = 1d) {
            // do nothing if nothing set
            if(orientation == ArrangeOrientation.None) return;
            if(shrinkFactor == 0d|| shrinkFactor > 1d) shrinkFactor = 1d;
            // buffer controls in separate list to avoid manipulating parameter
            List<Control> ctrl = new List<Control>(controls.ToArray());
            // remove invisible controls
            int j = 0;
            while(j < ctrl.Count) {
                if(!ctrl[j].Visible) ctrl.RemoveAt(j);
                else j++;
            }
            // loop arrangement
            int count = ctrl.Count;
            int xDelta, yDelta, xOffs, yOffs, y, x, columns, rows, parentWidth, parentHeight, xShrinkOffs, yShrinkOffs;
            if(count >= 1) {
                // parents size
                parentWidth = ctrl[0].Parent.Width;
                parentHeight = ctrl[0].Parent.Height;
                // shrink factor offset
                parentWidth = Convert.ToInt32(parentWidth * shrinkFactor);
                parentHeight = Convert.ToInt32(parentHeight * shrinkFactor);
                // shrink factor offset
                xShrinkOffs = Convert.ToInt32((ctrl[0].Parent.Width - parentWidth) / 2d);
                yShrinkOffs = Convert.ToInt32((ctrl[0].Parent.Height - parentHeight) / 2d);
                // calculate columns rows grid layout                            
                if(orientation == ArrangeOrientation.Horizonatal) {
                    rows = 1;
                    columns = count;
                }
                else if(orientation == ArrangeOrientation.Vertical) {
                    rows = count;
                    columns = 1;
                }
                else if(orientation == ArrangeOrientation.TopLeftGrid
                    || orientation == ArrangeOrientation.TopRightGrid
                    || orientation == ArrangeOrientation.BottomLeftGrid
                    || orientation == ArrangeOrientation.BottomRightGrid) {
                    rows = 1;
                    columns = count;
                }
                else {
                    rows = Convert.ToInt32(Math.Floor(Math.Sqrt(count)));
                    if(Math.Sqrt(count) % 1d != 0d) rows++;
                    columns = count / rows + (count % rows != 0 ? 1 : 0);
                }
                if(orientation == ArrangeOrientation.HorizontalGrid) {
                    int swap = columns;
                    columns = rows;
                    rows = columns;
                }
                // calculate position offsets, grid distance
                xDelta = parentWidth / count;
                yDelta = parentHeight / count;
                xOffs = xDelta / 2;
                yOffs = yDelta / 2;                
                if(orientation == ArrangeOrientation.TopLeftGrid) {                                                     
                }
                else if(orientation == ArrangeOrientation.TopRightGrid) {
                    xOffs = parentWidth - xOffs;
                    xDelta = -xDelta;
                }
                else if(orientation == ArrangeOrientation.BottomLeftGrid) {
                    yOffs = parentHeight - yOffs;
                    yDelta = -yDelta;
                }
                else if(orientation == ArrangeOrientation.BottomRightGrid) {
                    xOffs = parentWidth - xOffs;
                    yOffs = parentHeight - yOffs;
                    xDelta = -xDelta;
                    yDelta = -yDelta;
                }
                else {
                    xDelta = parentWidth / columns;
                    yDelta = parentHeight / rows;
                    xOffs = xDelta / 2;
                    yOffs = yDelta / 2;
                }
                // fit controls in grid layout               
                Point pRoot = new Point(/*ctrl[0].Parent.Location.X + */xOffs, /*ctrl[0].Parent.Location.Y + */yOffs);
                y = 0; x = 0;
                for(int i = 0; i < count; i++) {
                    if(orientation == ArrangeOrientation.VerticalGrid) {
                        // actual x/y - points zero based index
                        y = Convert.ToInt32(Math.Floor((double)i % rows));
                        // next row? zero based index
                        if(i % rows == 0 && i != 0) x++;
                    }
                    else {
                        // actual x/y - points zero based index
                        x = Convert.ToInt32(Math.Floor((double)i % columns));
                        // next row? zero based index
                        if(i % columns == 0 && i != 0) y++;
                        if(orientation == ArrangeOrientation.TopLeftGrid
                            || orientation == ArrangeOrientation.TopRightGrid
                            || orientation == ArrangeOrientation.BottomLeftGrid
                            || orientation == ArrangeOrientation.BottomRightGrid)
                            y = x;
                    }                   // assign controls to grid
                    ctrl[i].Location = new Point(pRoot.X + x * xDelta - ctrl[i].Size.Width / 2 + xShrinkOffs, pRoot.Y + y * yDelta - ctrl[i].Size.Height / 2 + yShrinkOffs);
                }
            }
        }
