     List<user> userList = new List<user>();
            
            foreach (user usr in userList)
            {
                PlaceHolder1.Controls.Add(new CheckBox()
                                              {
                                                  ID = "cb_"+usr.UserId,
                                                  Text = usr.Name,
                                                  });    
            }
