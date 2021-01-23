    string emailto = null;
    string emailcc1 = null;
    string emailcc2 = null;
    string emailcc3 = null;
    foreach (DataRow newRow in employee.Rows)
    {
        num = num - 1;
        switch (num)
        {
           case 4:
              emailto = newRow["EMAILID"].ToString();
              break;
           case 3:
              emailcc1 = newRow["EMAILID"].ToString();
              break;
           case 2:
              emailcc2 = newRow["EMAILID"].ToString();
              break;
           case 1:
              emailcc3 = newRow["EMAILID"].ToString();
              break;
           default:
              //Do something here?
        }
    }
