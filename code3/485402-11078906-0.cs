     foreach (Control cntrl in Panel1.Controls)
            {
                System.Reflection.PropertyInfo[] props = cntrl.GetType().GetProperties();
                IEnumerable<System.Reflection.PropertyInfo> searchedProp = props.Where(delegate(System.Reflection.PropertyInfo p)
                                                                            {
                                                                                return p.Name.Contains("YourPropertyName");
                                                                            });
                if (searchedProp != null && searchedProp.Count() > 0)
                    searchedProp.First().SetValue(cntrl, true, null); // Here true should be replaced by the value that is allowed by the property you are setting at runtime
            }
