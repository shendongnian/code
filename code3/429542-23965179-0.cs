        public int firstVisible(ListView lv)
        {
            int i = 1;
            try
            {
                while (lv.GetItemRect(i).X != 0) i++;
            }
            catch
            {
                return 0;
            }
            int rowWidth = i;
            int rowHeight = lv.GetItemRect(i).Y - lv.GetItemRect(0).Y;
            return -((int)lv.GetItemRect(0).Y / rowHeight) * rowWidth;
        }
