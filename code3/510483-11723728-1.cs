    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            var rows = new List<Row>();
            var sr = new StreamReader(@"C:\so_test.txt");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (!String.IsNullOrEmpty(s.Trim()))
                {
                    rows.Add(new Row(s));
                }
            }
            sr.Close();
            dataGridView1.DataSource = rows;
        }
    }
    public class Row
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public double Number3 { get; set; }
        public double Number4 { get; set; }
        public double Number5 { get; set; }
        public double Number6 { get; set; }
        public double Number7 { get; set; }
        public string Date1 { get; set; }
        public Row(string str)
        {
            string[] separator = { "\t" };
            var arr = str.Split(separator, StringSplitOptions.None);
            Number1 = Convert.ToDouble(arr[0]);
            Number2 = Convert.ToDouble(arr[1]);
            Number3 = Convert.ToDouble(arr[2]);
            Number4 = Convert.ToDouble(arr[3]);
            Number5 = Convert.ToDouble(arr[4]);
            Number6 = Convert.ToDouble(arr[5]);
            Number7 = Convert.ToDouble(arr[6]);
            Date1 = arr[7];
        }
    }
