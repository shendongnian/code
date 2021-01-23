                public bool UserLogin(string User, string Pass)
                {
                    var Database = new ExampleDataSet();
                    var query = from Employee in Database.Employee
                                where (Employee.EmployeeID.ToString().ToLower().Equals(User.ToLower())&& Employee.Password.ToString().ToLower().Equals(Pass.ToLower())
                                select Employee;
                    if (query.Count() != 0)
                    {
                        MessageBox.Show("You are logged in");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("You are not logged in");
                        return false;
                    }
                    
                    
                }
                private void cmdLogin_Click(object sender, EventArgs e)
                {
                string User = (txtUser.Text);
                string Pass = (txtPass.Text);
                UserLogin(User, Pass);
                }
