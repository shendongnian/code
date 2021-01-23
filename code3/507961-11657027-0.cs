    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // This line registers the event, soc that the form can "hear" it and call the indicated handling code:
            this.listView1.ColumnWidthChanging += new 
            ColumnWidthChangingEventHandler(listView1_ColumnWidthChanging);
        }
        void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            Console.Write("Column Resizing");
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
    }
