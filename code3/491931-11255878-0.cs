    if (TypeDropDownList.Items.Count == 0)
                {
                    foreach (TypeDesc newPatient in EnumToDropDown.EnumToList<TypeDesc>())
                    {
                        string text = EnumToDropDown.GetEnumDescription(newPatient);
    
                        TypeDropDownList.Items.Add(new ListItem(text, newPatient.ToString()));
                    }
                }
