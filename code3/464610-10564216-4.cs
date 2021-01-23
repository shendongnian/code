        private void showMonthCalendar(object sender, EventArgs e) {
            dateTimePicker1.Focus();
            using (var dlg = new CalendarForm()) {
                dlg.DateSelected += new DateRangeEventHandler((s, ea) => dateTimePicker1.Value = ea.Start);
                dlg.Location = dateTimePicker1.PointToScreen(new Point(0, dateTimePicker1.Height));
                dlg.ShowDialog(this);
            }
        }
