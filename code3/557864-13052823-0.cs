    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void CandleStick_Load(object sender, EventArgs e)
        {
            GrafiekLaden();
        }
        public void GrafiekLaden()
        {
            // fake the DB data with a simple list
            List<dbdata> k = new List<dbdata> { 
                new dbdata("1/1/2012", 10f, 8f, 9f, 9.5f),
                new dbdata("2/1/2012", 15F, 10F, 12F, 13F),
                new dbdata("3/1/2012", 5F, 10F, 8F, 6F),
                new dbdata("4/1/2012", 25F, 10F, 18F, 16F)
            };
            Series price = new Series("price"); // <<== make sure to name the series "price"
            chart1.Series.Add(price);
            // Set series chart type
            chart1.Series["price"].ChartType = SeriesChartType.Candlestick;
            // Set the style of the open-close marks
            chart1.Series["price"]["OpenCloseStyle"] = "Triangle";
            // Show both open and close marks
            chart1.Series["price"]["ShowOpenClose"] = "Both";
            // Set point width
            chart1.Series["price"]["PointWidth"] = "1.0";
            // Set colors bars
            chart1.Series["price"]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            chart1.Series["price"]["PriceDownColor"] = "Red"; // <<== use text indexer for series
            for (int i = 0; i < k.Count; i++)
            {
                // adding date and high
                chart1.Series["price"].Points.AddXY(DateTime.Parse(k[i].Datum), k[i].Hoog);
                // adding low
                chart1.Series["price"].Points[i].YValues[1] = k[i].Laag;
                //adding open
                chart1.Series["price"].Points[i].YValues[2] = k[i].PrijsOpen;
                // adding close
                chart1.Series["price"].Points[i].YValues[3] = k[i].PrijsGesloten;
            }
        }
    }
    class dbdata
    {
        public string Datum;
        public float Hoog;
        public float Laag;
        public float PrijsOpen;
        public float PrijsGesloten;
        public dbdata(string d, float h, float l, float o, float c) { Datum = d; Hoog = h; Laag = l; PrijsOpen = o; PrijsGesloten = c; }
    }
