    <Controls:DataGridComboBoxColumn Header="Gender" ItemsSource="{Binding Path=Genders}" />
        public ObservableCollection<string> Genders
        {
            get {
                return _genders;
            }
            set { _genders = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Genders"));
            }
        }
