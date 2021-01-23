    private DataTable dt;
    public Form1() {
      InitializeComponent();
      dt = new DataTable();
      dt.Columns.Add("ID", typeof(int));
      dt.Columns.Add("XCord", typeof(int));
      dt.Columns.Add("YCord", typeof(int));
      DataRow dr1 = dt.NewRow();
      dr1["ID"] = 1;
      dr1["XCord"] = 10;
      dr1["YCord"] = 10;
      dt.Rows.Add(dr1);
      DataRow dr2 = dt.NewRow();
      dr2["ID"] = 2;
      dr2["XCord"] = 10;
      dr2["YCord"] = 50;
      dt.Rows.Add(dr2);
      DataRow dr3 = dt.NewRow();
      dr3["ID"] = 3;
      dr3["XCord"] = 25;
      dr3["YCord"] = 50;
      dt.Rows.Add(dr3);
      panel1.Paint += panel1_Paint;
    }
