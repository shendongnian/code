            public class Employees
            {
                public int employeeID { get; set; }
                public int? parentEmployeeID { get; set; }
                public string Name { get; set; }
                public string Position { get; set; }
    
                public List<Employees> Children { get; set; }
            }
            public void Arrange()
            {
                Employeelist = ArrangeListWithRecursion();
            }
            private List<Employees> ArrangeListWithRecursion(int? parentId = null)
            {
                var result = new List<Employees>();
                foreach (var employee in Employeelist.Where(e => e.parentEmployeeID == parentId))
                {
                    var children = Employeelist.Where(e => e.parentEmployeeID == employee.employeeID).ToList();
                    employee.Children = ArrangeListWithRecursion(employee.employeeID);
                    result.Add(employee);
                }
                return result;
            }
