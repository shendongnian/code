    public class DataModel
    {
      public DataModel()
      {
        using (var dbContext = new DatabaseContext())
        {
          Employees = from e in dbContext.Employee
                      select new EmployeeDto
                      {
                        ID = e.EmployeeID,
                        DepartmentID = e.DepartmentID,
                        AddressID = e.AddressID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        StreetNumber = e.Address.StreetNumber,
                        StreetName = e.Address.StreetName
                      };
        }
      }
    
      /// <summary>Returns the list of employees.</summary>
      public IQueryable<EmployeeDto> Employees { get; private set; }
    }
