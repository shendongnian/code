    ... 
    class A
    {
        private ObservableCollection<string> variables = new ObservableCollection<string>();
        ...
        private void FillVariablesList() 
        {
            variables.Clear();
            variables.Add(""); 
            variables.Add(New_Variable); 
            foreach (Variable v in this.theTaskHost.Variables) 
            { 
                if (!v.SystemVariable && v.DataType == TypeCode.String) 
                    variables.Add(v.Name); 
            }
            this.comboBox.DataSource = null;
            this.comboBox.DataSource = variables;
        }
    }
