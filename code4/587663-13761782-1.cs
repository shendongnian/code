    public Form1()
        {
            InitializeComponent();
            PrepareTestData();
            int uniqueId = 0;
            var result = (from a in TableA
                          //Map soldiers to ShipmentReportItem
                          select new ShipmentReportItem
                          {
                              UniqueId = uniqueId++,
                              InnerId = a.Id,
                              Name = a.FirstName + " " + a.LastName,
                              Date = a.Date,
                          })
                        .Union(from b in TableB
                               select new ShipmentReportItem 
                               {
                                   UniqueId = uniqueId++,
                                   InnerId = b.Id,
                                   Name = b.ItemName,
                                   Date = b.Date,
                               }).OrderByDescending(x => x.Date).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = result;
        }
