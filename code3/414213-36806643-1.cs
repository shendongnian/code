    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
            void AddItems( string[] items )
            {
                if(InvokeRequired)
                {
                    Invoke((MethodInvoker) delegate { this.AddItems(items); });
                    return;
                }
                ListViewItem[] range = (items.Select<string, ListViewItem>(item => new ListViewItem(item))).ToArray();
                listView1.Items.AddRange(range);
            }
        }
    }
