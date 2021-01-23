     public partial class MDIChild : Form
        {
            public virtual string GetMessage()
            {
                return this.Name;
            }    
        }
    
        public class Form2 : MDIChild
        {
            TextBox textBox1 = new TextBox();
    
            public override string  GetMessage()
            {
                return textBox1.Text;
            }
        }
    
    
        public partial class MDIParent1 : Form
        {
            private MdiClient mdi = null;
            private string fname;
            private MDIChild currentActiveChild;
    
            public MDIParent1()
            {
                base.InitializeComponent();
                foreach (Control c in this.Controls)
                {
                    if (c is MdiClient)
                    {
                        mdi = (MdiClient) c;
                        break;
                    }
                }
            }
    
            private void ShowNewForm(object sender, EventArgs e)
            {
                currentActiveChild = new Form2();
                load_form(currentActiveChild);
            }
    
            public void getdata()
            {
                if (currentActiveChild != null)
                {
                    MessageBox.Show(currentActiveChild.GetMessage());
                }
            }
        }
