    public partial class UserControl1 : UserControl
        {
            private List<Button> buttons = new List<Button>(9);
            public UserControl1()
            {
                InitializeComponent();
            }
    
            private void UserControl1_Load(object sender, EventArgs e)
            {
                int line = 0;
                int lastleft = 0;
                int lasttop = 0;
                for (int i = 1; i < 10; i++)
                {
                    Button btn = new Button();
                    btn.Text = string.Empty;
                    btn.Parent = this;
                    btn.Top = lasttop;
                    btn.Left = lastleft;
                    btn.Width = 30;
                    btn.Height = 30;
                    btn.Name = i.ToString(CultureInfo.InvariantCulture);
    
                    if (i % 3 == 0)
                    {
                        lastleft = 0;
                        lasttop += 35; // 30 for height and 5 for spacing
                    }
                    else
                    {
                        lastleft += 35; // 30 for width and 5 for spacing
                    }
                    btn.Click += BtnOnClick;
                    buttons.Add(btn);
    
                }
            }
    
            private void BtnOnClick(object sender, EventArgs eventArgs)
            {
                //ur logic to check game status
                // how to know button?
                Button btn = sender as Button;
    
                if (btn != null)
                {
                    MessageBox.Show(String.Format("You clicked : {0}", btn.Name), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
