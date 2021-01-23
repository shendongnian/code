    public class HuntingDate
    {
        public HuntingDate(DateTime start, DateTime end)
        {
            _start = start;
            _end   = end;
        }
        public DateTime End
        {
            get
            {
                return _end;
            }
        }
        public DateTime Start
        {
            get
            {
                return _start;
            }
        }
        private readonly DateTime _start;
        private readonly DateTime _end;
    }
