    private void button1_Click(object sender, EventArgs e)
    {
        if(checkbox1_Member.Checked==true)
        {
                  Members obj = new Members();
                  obj.Name = "";
                  obj.Age = "";
                  obj.COB = "";
                  MessageBox.Show(obj.Name+ " :: " +"obj.Age.ToString());
        }
        else if(checkbox2_Employee.Checked==true)
        {
                  Employees obj1 = new Employees();
                  obj1.Salary = "";
                  obj1.JobTitle = "";             
                  MessageBox.Show (obj1.Salary.ToString()+ " ::"+obj.JobTitle.ToString());
        }
    }
     
