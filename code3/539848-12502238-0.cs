    BindingSource bindingSource1 = new BindingSource();
    bindingSource1.DataSource = (from r in ctx.tblTimeRecords
                            where (r.tblEmployee.Active && !r.ClockOut.HasValue) || System.Data.Objects.EntityFunctions.DiffDays(r.ClockOut, DateTime.Now)<30
                            select new { Name = r.tblEmployee.Last + ", " + r.tblEmployee.First, r.tblProject.ProjName, r.ClockIn, r.ClockOut }).ToList();
    
    dataGridView1.DataSource = bindingSource1;
