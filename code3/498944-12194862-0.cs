    public ObservableCollection<string> FillVariableList()
            {
                ObservableCollection<string> variables = new ObservableCollection<string>();
                
                variables.Add(string.Empty);
                variables.Add(New_Variable);        
    
                foreach (Variable v in thetaskHost.Variables)
                {
                    if (!v.SystemVariable && v.DataType == TypeCode.String && !variables.Contains(v.Name))
                    {
                        variables.Add(v.Name);                  
                    }
                }
    
                return variables;
            }
