        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = dateTimePicker2.Location;
            Point mouse_pt = dateTimePicker2.Parent.PointToClient(Cursor.Position);
            int diff_x = mouse_pt.X - pt.X;
            int diff_y = mouse_pt.Y - pt.Y;
            if (diff_y < dateTimePicker2.Size.Height || diff_x > dateTimePicker2.Size.Width )
                return;
            DateTime tim_cal = dateTimePicker2.Value;
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(now.Hour, now.Minute, now.Second);
            tim_cal = tim_cal.Date + ts;
            dateTimePicker2.Value = tim_cal;
        }
