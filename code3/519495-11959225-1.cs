    public partial class ContentCollection : UserControl
    {
        public ContentCollection()
        {
            InitializeComponent();
            RowContent one = new RowContent();
            RowContent two = new RowContent();
            RowContent three = new RowContent();
            RowContent four = new RowContent();
            RowContent five = new RowContent();
            RowContent six = new RowContent();
            tableLayoutPanel1.Controls.Add(one);
            tableLayoutPanel1.Controls.Add(two);
            tableLayoutPanel1.Controls.Add(three);
            tableLayoutPanel1.Controls.Add(four);
            tableLayoutPanel1.Controls.Add(five);
            tableLayoutPanel1.Controls.Add(six);
            tableLayoutPanel1.SetRow(one, 0);
            tableLayoutPanel1.SetRow(two, 1);
            tableLayoutPanel1.SetRow(three, 2);
            tableLayoutPanel1.SetRow(four, 3);
            tableLayoutPanel1.SetRow(five, 4);
            tableLayoutPanel1.SetRow(six, 5);
        }
    }
