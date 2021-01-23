                    DataSet ds = new DataSet();
                    ds = obj.getXmlData();// get the multiple table in dataset.
    
                    Employee objEmp = new Employee ();// create the object of class Employee 
                    List<Employee > empList = new List<Employee >();
                    int table = Convert.ToInt32(ds.Tables.Count);// count the number of table in dataset
                    for (int i = 1; i < table; i++)// set the table value in list one by one
                    {
                        foreach (DataRow dr in ds.Tables[i].Rows)
                        {
                            empList.Add(new Employee { Title1 = Convert.ToString(dr["Title"]), Hosting1 = Convert.ToString(dr["Hosting"]), Startdate1 = Convert.ToString(dr["Startdate"]), ExpDate1 = Convert.ToString(dr["ExpDate"]) });
                        }
                    }
                    dataGridView1.DataSource = empList;
