        //soldiers
        public class RowA
        {
            public long Id {get;set;}
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Date { get; set; }
        }
        //items
        public class RowB
        {
            public long Id {get;set;}
            public string ItemName { get; set; }
            public decimal Quantity { get; set; }
            public DateTime Date { get; set; }
        }
        List<RowA> TableA;
        List<RowB> TableB;
        public Form1()
        {
            InitializeComponent();
            PrepareTestData();
            int uniqueId = 0;
            var result = (from a in TableA
                          //Map soldiers to anonymous
                          select new 
                          {
                              UniqueId = uniqueId++,
                              InnerId = a.Id,
                              Name = a.FirstName + " " + a.LastName,
                              Date = a.Date,
                          })
                        .Union(from b in TableB
                               select new 
                               {
                                   UniqueId = uniqueId++,
                                   InnerId = b.Id,
                                   Name = b.ItemName,
                                   Date = b.Date,
                               }).OrderByDescending(x => x.Date).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = result;
        }
        void PrepareTestData()
        {
            TableA = new List<RowA>();
            for (int i = 0; i < 7; ++i)
                TableA.Add(new RowA
                {
                    Id = i + 1,
                    FirstName = "Name" + i,
                    LastName = "Surname" + i,
                    Date = DateTime.Now.AddDays(-i)
                });
            TableB = new List<RowB>();
            for (int j = 0; j < 4; ++j)
                TableB.Add(new RowB
                {
                    Id = j + 1,
                    ItemName = "Laser pistol",
                    Quantity = 7,
                    Date = DateTime.Now.AddDays(-j)
                });
        }
