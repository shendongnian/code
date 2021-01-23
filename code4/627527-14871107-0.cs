    private void Form1_Load(object sender, EventArgs e)
    {
        using (NorthWindDataContext dataContext = new NorthWindDataContext())
        {
            DateTime today = DateTime.Today;
            var q1 = from z in dataContext.Employees
                     select new
                     {
                         Name = z.FirstName,
                         Age = today - z.BirthDate
                     };
            dataGridView1.DataSource = q1;
        }
    }
