        protected void DoLogin()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };
            // save it to session
            Session.Add("Employee", employee);
        }
