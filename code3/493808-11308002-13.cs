    [HttpPost]
    public ActionResult Index(RequestViewModel request)
    {
        int id = request.Customers;
        int scheduleId = request.Jobs;
        DataTable dt = JobOperation.GetJobsBySchedulerIdAndCustomerId(scheduleId, id);
        // Now let's build the view model for the result:
        var model = new MyViewModel();
        model.Columns = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName);
        model.Values = dt.AsDynamicEnumerable();
        model.Customers = new SelectList(CustomerOperation.GetCustomers().Items, "Id", "Name");
        model.Jobs = new SelectList(JobOperation.GetCustomersAssemblyList().Items, "scheduleId", "name");
        return View(model);
    }
