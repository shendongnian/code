        public TimeSpan PartDays
        {
            get
            {
                var startInEndsMonth = Start.AddMonths(WholeMonths);
                return End.Subtract(startInEndsMonth);
            }
        }
