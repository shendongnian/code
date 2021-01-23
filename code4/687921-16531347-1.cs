    var docs = (Long LINQ query that joins in four different tables and returns a model)
    MyViewModel vm = new MyViewModel();
    vm.Master = docs; // I guess docs is a list of Masterlist
    vm.DepartmentList = db.Department.Where(x => (x.name != null)).Select(s => new SelectListItem
                {
                    Value = s.name,
                    Text = s.name
                })
                .Distinct();  //  Fill the viewbag with a unique list of 'Department's from the table.
    
    vm.FunctionList = db.Function.Where(x => (x.name != null)).Select(s => new SelectListItem
                {
                    Value = s.name,
                    Text = s.name
                })
                .Distinct();  //  Fill the viewbag with a unique list of 'Function's from the table.
    return View(vm);
