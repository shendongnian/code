    public partial class Form1 : Form
    {
        public Color color1;
        public Color color2;
        public int rowhandle;
        public List<int> rowhandles;
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (rowhandles.Any(x=>x==e.RowHandle))
                {
                    if (color1 != null && color2 != null)
                    {
                        e.Appearance.BackColor = color1;
                        e.Appearance.BackColor2 = color2;
                    }
                }
            }
            catch
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            color1 = Color.BurlyWood;
            color2 = Color.DarkOrchid;
            rowhandle = gridView1.FocusedRowHandle;
            if (!rowhandles.Any(x => x == rowhandle))
                rowhandles.Add(rowhandle);
            gridView1.RefreshRow(rowhandle);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> l = new Dictionary<int, string>();
            l.Add(1,"one");
            l.Add(2,"two");
            l.Add(3,"three");
            l.Add(4, "four");
            l.Add(5, "five");
            l.Add(6, "six");
            l.Add(7, "seven");
            l.Add(8, "eight");
            l.Add(9, "nine");
            gridControl1.DataSource = l.ToList();
            rowhandles = new List<int>();
        }
    }
