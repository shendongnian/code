        public static DataGridView SetGridHeightWidth(DataGridView grd, int maxHeight, int maxWidth)
        {
            var height = 40;
            foreach (DataGridViewRow row in grd.Rows)
            {
                if(row.Visible)
                    height += row.Height;
            }
            if (height > maxHeight)
                height = maxHeight;
            grd.Height = height;
            var width = 60;
            foreach (DataGridViewColumn col in grd.Columns)
            {
                if (col.Visible)
                    width += col.Width;
            }
            if (width > maxWidth)
                width = maxWidth;
            grd.Width = width;
            return grd;
        }
