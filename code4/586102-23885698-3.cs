    private Boolean isCustomerDetailChecked = false;
        public Boolean IsCustomerDetailChecked
        {
            get
            {
                return isCustomerDetailChecked;
            }
            set
            {
                isCustomerDetailChecked = value;
                InvokePropertyChanged("IsCustomerDetailChecked");
            }
        }
