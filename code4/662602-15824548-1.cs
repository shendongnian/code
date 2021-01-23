        //your stuff on getting the role of the user 
       //validation stuff
        string role =  // get user role;  
        if (role!=null)
                {
                     //if you have MDI Parent
                    var mdi = new MDIParent
                                  {
                                      UserName = txtUserName.Text,
                                      Role = role,
                                  };
                     mdi.Show();    
                     this.Hide();
                }
                else
                {
                   //Error user not valid!!
                }
