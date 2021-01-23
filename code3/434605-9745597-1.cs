    var employees = new IEnumerable<Employee>();
    using (var gr = new GenericRepo<Employee>())
    {
        employees = gr.Get();
    }
    vm.Employees = employees.ToSelectList(x=>x.FirstName + " " + x.LastName, x=>x.Id, "-- Select Employee --")
