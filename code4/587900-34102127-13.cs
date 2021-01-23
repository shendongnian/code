    private DataTable employeeDataTable;
    
    public DataTable EmployeeDataTable
    {
       get { return employeeDataTable; }
       set
       {
          employeeDataTable = value;
          OnPropertyChanged("EmployeeDataTable");
       }
    }
    
    private void PopulateDataTable()
    {
        var _ds = new DataSet("Test");
        employeeDataTable = new DataTable();
        employeeDataTable = _ds.Tables.Add("DT");
        for (int i = 0; i < 800; i++)
        {
           if(i%2==0)
               employeeDataTable.Columns.Add(i.ToString() + ".");
           else
               employeeDataTable.Columns.Add(i.ToString() + "/");
        }
        for (int i = 0; i < 2; i++)
        {
           var theRow = employeeDataTable.NewRow();
           for (int j = 0; j < 800; j++)
           {
              if (j % 2 == 0)
              {
                //theRow[j] = j.ToString();
                theRow[j] = "a";
              }
              else
                theRow[j] = CreateDoubleValue(j).ToString();
         }
        employeeDataTable.Rows.Add(theRow);
        }
    }
