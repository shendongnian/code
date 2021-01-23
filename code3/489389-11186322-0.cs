    <ComboBox ITemsSource="{Binding Hours}" SelectedItem="{Binding SelectedItem}" />
    
    class ViewModel
    {
        public string SelectedItem {get; set;}
    }
