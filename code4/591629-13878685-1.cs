    namespace activator
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
           {
            DataTable dt = new DataTable();
            dt.Columns.Add("Media", typeof(string));
            dt.Rows.Add("Truck");
            dt.Rows.Add("Car");            
            ComboBox combo = new ComboBox();
            List<string> media=(from x in dt.AsEnumerable()
                                select x.Field<string>(0)).ToList();
            combo.DataSource = media;
            dataGridView1.Controls.Add(combo);           
        }
      }
    }
