     private void GetFormNames()
        {
    
    
            Type[] AllTypesInProjects = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < AllTypesInProjects.Length; i++)
                {
                    if (AllTypesInProjects[i].BaseType == typeof(Form))
                    {            /* Convert Type to Object */
                        Form f = (Form)Activator.CreateInstance(AllTypesInProjects[i]);
                        string FormText = f.Text; 
                        listBox1.Items.Add(FormText);
                    }
                }
            
        }
