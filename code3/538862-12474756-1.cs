     var _isEditable = _empColl.ToDictionary(item => item.EmployeeID,
                                             item => item.GetType()
                                                      .GetProperties()
                                                      .ToDictionary(pro => pro.Name, 
                                                                    pro => false));
