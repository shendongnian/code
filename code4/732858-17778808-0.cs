     private class User
        {
            public string Location = "MyLocation";
            public string Role = "Role";
            public string Data = "TestData";
        }
    private void LinqOr()
        {
            //throw new NotImplementedException();
            IEnumerable<User> users = new User[] {
                            new User{Location="MyLocation",Role="Role",Data="Data1"},
                            new User{Location="MyLocation",Role="Role",Data="Data2"},
                            new User{Location="MyLocationB",Role="Role3",Data="Data3"},
                            new User{Location="MyLocationB",Role="Role4",Data="Data4"},
                            new User{Location="MyLocationC",Role="Role",Data="Data5"},
                            new User{Location="MyLocationC",Role="Role",Data="Data6"},
                            new User{Location="MyLocationD",Role="Role7",Data="Data7"},
            };
            //users = users.Where(l => l.Location == "MyLocation");
            //users = users.Where(R => R.Role == "Role");
            //users = users.Where(u => u.Location == "MyLocation" && u.Role == "Role");
            users = users.Where(u => u.Location == "MyLocation" || u.Role == "Role");
            string result = "";
            foreach (User user in users)
            {
                result += user.Location + " " + user.Role + " " + user.Data + "\r\n";
            }
            MessageBox.Show(result);
        }
    
        private void btnTest_Click(object sender, EventArgs e)
        {          
            LinqOr();
        }
