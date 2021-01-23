                DateTime StartDate = Convert.ToDateTime(RadDatePickerStart.SelectedDate);
                DateTime EndDate = Convert.ToDateTime(RadDatePickerEnd.SelectedDate);
                TimeSpan StartTime, EndTime;
                if (RadTimePickerStart.SelectedDate != null)
                    StartTime = RadTimePickerStart.SelectedDate.Value.TimeOfDay;
                if (RadTimePickerEnd.SelectedDate != null)
                    EndTime = RadTimePickerEnd.SelectedDate.Value.TimeOfDay;
                RadDatePickerStart.SelectedDate = StartDate + StartTime;
                RadDatePickerEnd.SelectedDate = EndDate + EndTime;
