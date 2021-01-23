        public int WholeYears
        {
            get
            {
                return (int) Math.Floor(WholeMonths/12d);
            }
        }
        public int PartMonths
        {
            get
            {
                return WholeMonths % 12;
            }
        }
