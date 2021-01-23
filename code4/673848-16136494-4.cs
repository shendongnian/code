    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog theDialog = new OpenFileDialog();
        theDialog.Title = "Open Text File";
        theDialog.Filter = "TXT files|*.txt";
        theDialog.InitialDirectory = @"C:\";
        if (theDialog.ShowDialog() == DialogResult.OK)
        {
            string filename = theDialog.FileName;
            string[] filelines = File.ReadAllLines(filename);
            List<Employee> employeeList = new List<Employee>();
            int linesPerEmployee = 4;
            int currEmployeeLine = 0;
            //parse line by line into instance of employee class
            Employee employee = new Employee();
            for (int a = 0; a < filelines.Length; a++)
            {
                //check if to move to next employee
                if (a != 0 && a % linesPerEmployee == 0)
                {
                    employeeList.Add(employee);
                    employee = new Employee();
                    currEmployeeLine = 1;
                }
                else
                {
                    currEmployeeLine++;
                }
                switch (currEmployeeLine)
                {
                    case 1:
                        employee.EmployeeNum = Convert.ToInt32(filelines[a].Trim());
                        break;
                    case 2:
                        employee.Name = filelines[a].Trim();
                        break;
                    case 3:
                        employee.Address = filelines[a].Trim();
                        break;
                    case 4:
                        string[] splitLines = filelines[a].Split(' ');
                            
                        employee.Wage = Convert.ToDouble(splitLines[0].Trim());
                        employee.Hours = Convert.ToDouble(splitLines[1].Trim());
                        break;
                }
            }
            //Test to see if it works
            foreach (Employee emp in employeeList)
            {
                MessageBox.Show(emp.EmployeeNum + Environment.NewLine +
                    emp.Name + Environment.NewLine +
                    emp.Address + Environment.NewLine +
                    emp.Wage + Environment.NewLine +
                    emp.Hours + Environment.NewLine);
            }
        }
    }
