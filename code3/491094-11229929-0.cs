    public partial class Form1
    {
       public Form1()
       {
          InitializeComponent();
          var list = new List<Data>();
          list.Add(new Data { Prop1 = 1, Prop2 = 1.2 });
          list.Add(new Data { Prop1 = 2, Prop2 = 1.234567 });
          dataGridView1.Columns.Add("Prop1", "Prop1");
          dataGridView1.Columns["Prop1"].DataPropertyName = "Prop1";
          dataGridView1.Columns.Add("Prop2", "Prop2");
          dataGridView1.Columns["Prop2"].DataPropertyName = "Prop2";
          dataGridView1.Columns["Prop2"].DefaultCellStyle.Format = "0.00##";
          dataGridView1.DataSource = list;
       }
       class Data
       {
          public int Prop1 { get; set; }
          public double Prop2 { get; set; }
       }
    }
