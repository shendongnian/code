    class TimePicker : DomainUpDown
    {
        public TimePicker()
        {         
            // build the list of times, in reverse order because the up/down buttons go the other way
            for (double time = 23.5; time >= 0; time -= 0.5)
            {
                int hour = (int)time; // cast to an int, we only get the whole number which is what we want
                int minutes = (int)((time - hour) * 60); // subtract the hour from the time variable to get the remainder of the hour, then multiply by 60 as .5 * 60 = 30 and 0 * 60 = 0
                this.Items.Add(hour.ToString("00") + ":" + minutes.ToString("00")); // format the hour and minutes to always have two digits and concatenate them together with the colon between them, then add to the Items collection
            }
            this.SelectedIndex = Items.IndexOf("09:00"); // select a default time
            this.Wrap = true; // this enables the picker to go to the first or last item if it is at the end of the list (i.e. if the user gets to 23:30 it wraps back around to 00:00 and vice versa)
        }
    }
