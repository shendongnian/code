        public List<DisplayDateTime> GetDisplayDates()
        {
            var displayDates = new List<DisplayDateTime>();
            foreach (var d in Dates)
            {
                displayDates.Add(new DisplayDateTime(d));
            }
            return displayDates;
        }
