    public ListHelper SelectedDocumentType
	 {
	 	get { return _selectedDocumenType; }
		set 
		{
			_selectedDocumentType = value;
			// raise property change notification
		}
	}
    private ListHelper _selectedDocumentType;
…
    <ComboBox ItemsSource="{Binding DocumentTypeCmb, Mode=TwoWay}"
              SelectedItem="{Binding SelectedDocumentType, Mode=TwoWay}" />
