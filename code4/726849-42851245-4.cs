    private void ShowData()
                {
                    using (var uow = new UnitOfWork(new SellContext()))
                    {
                        listBox1.DataSource = uow.Departments.GetAll().ToList();
                        listBox1.DisplayMember = "DepartmentName";
                        listBox1.ValueMember = "DepartmentId"; 
                        listBox1.Invalidate();       
                    }
                }
