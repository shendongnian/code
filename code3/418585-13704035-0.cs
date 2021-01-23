        protected override void OnScroll(ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                e.NewValue = GetColumnOffset(e.NewValue);;
            }
            base.OnScroll(e);
        }
        private int GetColumnOffset(int offset)
        {
            int start = 0, end = 0;
            foreach (var column in Columns.Cast<DataGridViewColumn>().Where(c=>!c.Frozen))
            {
                end = start + column.Width;
                if (start <= offset && offset < end)
                {
                    break;
                }
                start = end;
            }
            return start == offset ? offset : end;
        }
