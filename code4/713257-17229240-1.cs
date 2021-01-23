    <ComboBox  ItemsSource="{Binding Path=SidJavnaUstanovaViewModel.Elements,
        Source={StaticResource StoreViewM}}" 
        SelectedItem="{Binding Path=SelectedModel,UpdateSourceTrigger=PropertyChanged, 
        Mode=TwoWay, Source={StaticResource StoreViewM}}" 
        DisplayMemberPath="Naziv">
    </ComboBox>
    .........................................
    //MainViewModel
    public SIDPoslJavnaUstanova SelectedModel
    {
        get { return _selectedModel; }
        set
        {
            if (_selectedModel != value)
            { 
                _selectedModel = value;
                RaisePropertyChanged("SelectedModel");
            }
        }
    }
