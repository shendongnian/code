        public bool BankFileSelected
        {
            get
            {
                return bankFileSelected;
            }
            set
            {
                bankFileSelected= value;
                yourViewModel.RaisePropertyChanged("AccountSelectedAndBankFileSelected");
            }
        }
