    foreach (Control control in panel1.Controls)
                    {
    
                        Type controlType = control.GetType();
                        switch (controlType.Name)
                        {
                            case "CheckBox":
                                if ((bool)controlType.GetProperty("Checked").GetValue(control,null))
                                    controlType.GetProperty("Name").SetValue(control,"Check1",null);                        
                                break;
                            case "TextBox":
                              //TODO
                                break;
                            case "ComboBox":
                               //TODO
                                break;
                            default:
                                break;
                        }
                    }
                }
