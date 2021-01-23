    SelectedValueBinding="{Binding SelectedValue, Mode=TwoWay}"
                                           SelectedValuePath="Value1">
    private string selectedValue;
        public string SelectedValue 
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                Notify("SelectedValue");
            } 
        }
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
