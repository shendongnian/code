        public DateTime GetNextPossibleDay(DateTime DT, DayOfWeek[] PossibleDays)
        {
            if (PossibleDays.Length == 0)
                throw new Exception("No possible day.");
            do
            {
                DT = DT.AddDays(1);
            }
            while (!PossibleDays.Contains(DT.DayOfWeek));
            return DT;
        }
