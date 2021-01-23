    class DateTimePickerUser : DateTimePicker
    {
        private bool userSetValue;
        public bool UserSetValue
        {
            get
            {
                return userSetValue;
            }
        }
        public DateTimePickerUser()
        {
            userSetValue = true;
        }
        public new DateTime Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                userSetValue = false;
                base.Value = value;
                userSetValue = true;
            }
        }
    }
