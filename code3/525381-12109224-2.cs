    DataGridTextColumn column = new DataGridTextColumn();
    column.Header = "Can Connect";
    Binding binding = new Binding("CanConnect");
    binding.Converter = new IsConnectedConverter();
    column.Binding = binding;
