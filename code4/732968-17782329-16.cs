    public partial class Form1 : Form
    {
        private delegate void SetCallback(ListViewItem row, string text);
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void SomeMethod()
        {
            Thread t = new Thread(() =>
            {
                foreach (ListViewItem row in listView1.Items)
                {
                    if (listView1.InvokeRequired)
                    {
                        SetCallback d = new SetCallback(SetText);
                        this.Invoke(d, new object[] { row, "Checking" });
                    }
    
                    Thread.Sleep(2000);
                }
            });
            t.Start();
        }
    
        private void SetText(ListViewItem row, string text)
        {
            row.SubItems[0].Text = text;
        }
    }
