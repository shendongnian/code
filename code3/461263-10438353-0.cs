    [Serializable()]
    public class UserSession
    {
        private CurrentRecord _CurrentRecord;
        public CurrentRecord CurrentRecord
        {
            get
            {
                if ((_CurrentRecord == null))
                {
                    _CurrentRecord = new CurrentRecord();
                }
                return _CurrentRecord;
            }
            set
            {
                if ((_CurrentRecord == null))
                {
                    _CurrentRecord = new CurrentRecord();
                }
                _CurrentRecord = value;
            }
        }
    }
