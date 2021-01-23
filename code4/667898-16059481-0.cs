    namespace  WindowsFormsApplication5
        {
            public partial class Form4 : Form
            {
                public Form4()
                {
                    InitializeComponent();
                    listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
                    listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView1_ItemSelectionChanged);
                    listView1.Items.Add("3434");
                    listView1.Items.Add("13434");
                    listBox1.Items.Add("3434");
                    listBox1.Items.Add("13434");
                }
        
                void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
                {
                    this.listBox1.SetSelected(this.listView1.FocusedItem.Index, true);
                }
        
                void listBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    this.listView1.Items[listBox1.SelectedIndex].Selected = true;
                }
            }
        }
