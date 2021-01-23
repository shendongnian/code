    private void Create_EmpDetails_Load(object sender, EventArgs e)
        {
            using (satsEntities Setupctx = new satsEntities())
            {
                var viewEmpName = (from viewEN in Setupctx.employees
                                   join ufi u in Setupctx.ufis on viewEN.UFISID equals u.UFISID
                                   select new { u.EmployeeName }).Distinct().ToList();
                cbName.DataSource = viewEmpName;
                cbName.DisplayMember = "EmployeeName";
                cbName.ValueMember = "EmployeeName";
                //cbName.ValueMember = "UFISID";
            }
        }
