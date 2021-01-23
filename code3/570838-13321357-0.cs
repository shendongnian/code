    using System.Windows.Forms;
    
    // ...
    
        Binding binding = new Binding("Text", this.personBindingSource, "Name");
        binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
    
        this.nameTextBox.DataBindings.Add(binding);
