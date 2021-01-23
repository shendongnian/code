    var result = (from cat in students
                              select new
                              {
                                  FirstName = cat.FirstName,
                                  LastName = cat.LastName,
                                  Gender = cat.Gender
                                  
                              }).Distinct().ToList().Where(oc=>oc.Gender == comboBox1.SelectedItem.ToString());
