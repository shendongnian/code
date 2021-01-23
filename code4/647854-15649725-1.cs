    public partial class Form1 : Form
    {
        MyListBox lb = new MyListBox();
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(lb);
            lb.ItemAdded += lb_ItemAdded;
        }
        void lb_ItemAdded(object sender, EventArgs e)
        {
            // process item here...
        }       
    }
