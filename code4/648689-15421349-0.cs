        public List<Employee> GetEmployees(Employee employee)
        {
            List<Employee> result = new List<Employee>() { employee };
            foreach (var child in employee.Children)
            {
                result.AddRange(GetEmployees(child));
            }
            return result;
        }
