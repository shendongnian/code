    private void button1_Click(object sender, EventArgs e)
        {
            try {
                using (var uow = new UnitOfWork(new SellContext()))
                {
                    int count = uow.Departments.FindDepartmentByName(txtDeptName.Text.ToString());
                    if (count>0)
                    {
                        MessageBox.Show("This Department Already Exists", "SellRight", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        department dept = new department();
                        dept.DepartmentName = txtDeptName.Text.ToString();
                        uow.Departments.Create(dept);
                        if (uow.Complete() > 0)
                        {
                           
                            MessageBox.Show("New Department Created", "SellRight", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDeptName.Text = "";
                            ShowData();
                            
                        }
                        else
                        {
                            MessageBox.Show("Unable to add Department", "SellRight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDeptName.Text = "";
                            ShowData();
                        }
                    }
                   
                }                              
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
