    class TestViewModel : ViewModelBase
    {
        bool checkDuplicates;
        public bool CheckDuplicates
        {
            get { return checkDuplicates; }
            set 
            {
                if(checkDuplicates != value)
                {
                    checkDuplicates = value;
                    OnPropertyChanged("CheckDuplicates");
                }
             }
        }
        //Everything else is same as before
        //  except the action
        public void AnyAction(object param)
        {
            //no need for param anymore
            //var parmValues = (Object)param;
            bool test = this.CheckDuplicates;
        }        
    }
