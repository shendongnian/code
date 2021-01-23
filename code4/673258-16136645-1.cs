         namespace SneakPeak
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
                private void Form1_Load(object sender, EventArgs e)
                {
                    listView1.ShowItemToolTips = true;
                    ListViewItem ItemA = new ListViewItem("my item A");
                    myObject ObjectA = new myObject("the description for A");
                    ItemA.Tag = ObjectA;
                    ItemA.ToolTipText = ((myObject) (ItemA.Tag)).ToString();
                    ListViewItem ItemB = new ListViewItem("my item B"); 
                    myObject ObjectB = new myObject("the description for B");
                    ItemB.Tag = ObjectB;
                    ItemB.ToolTipText = ((myObject)(ItemB.Tag)).ToString();
            
                    ListViewItem ItemC = new ListViewItem("my item C"); 
                    myObject ObjectC = new myObject("the description for C");
                    ItemC.Tag = ObjectC;
                    ItemC.ToolTipText = ((myObject)(ItemC.Tag)).ToString();
            
                    ListViewItem ItemD = new ListViewItem("my item D");
                    myObject ObjectD = new myObject("the last of the descriptions - description for D that goes off the side of the window");
                    ItemD.Tag = ObjectD;
                    ItemD.ToolTipText = ((myObject)(ItemD.Tag)).ToString();
            
                    listView1.Items.Add(ItemA);
                    listView1.Items.Add(ItemB);
                    listView1.Items.Add(ItemC);
                    listView1.Items.Add(ItemD);
                }
                public class myObject
                {
                    public string filePreview = "";
                    public override string ToString()
                    {
                        return filePreview;
                    }
                    public myObject(string s)
                    {
                        filePreview = s;
                    }
                }
                private void button1_Click(object sender, EventArgs e)
                {
                    Close();
                }
            }
        }
    
