    private void RefreshGrid()
            {
                  List<Employee> employees = GetEmployees(CountToDisplay)
                  if (employees != null)
                    {                    
                      empGrid.DataSource = employees;
                    }
    // **Hide the ShowMore link in case Count to display exceeds the total record.**
                   btnShowMore.Visible = employees.Count > CountToDisplay;
                   // Finally bind the GridView
                   empGrid.DataBind();
          }
    
       
