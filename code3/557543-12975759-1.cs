    struct Date
    {
        private DateTime dateTime;
        public Date(DateTime dateTime)
        {
            this.dateTime = dateTime.Date;
        }
        public override string ToString()
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
