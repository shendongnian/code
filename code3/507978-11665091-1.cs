     if (data.Data2 ==  null)//data is an object of DisplayedData class that we are showing in PropertyGrid
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(data.GetType())["Data2"];
                BrowsableAttribute attribute = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("Browsable",
                                      BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Public |
                                      BindingFlags.Instance);
                fieldToChange.SetValue(attribute, false);
                data.Data2Error = "Error";
                descriptor = TypeDescriptor.GetProperties(data.GetType())["Data2Error"];
                attribute = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                fieldToChange = attribute.GetType().GetField("Browsable",
                                      BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Public |
                                      BindingFlags.Instance);
                fieldToChange.SetValue(attribute, true);
            }
            propertyGrid1.SelectedObject = data; //Reassign object to PropertyGrid
