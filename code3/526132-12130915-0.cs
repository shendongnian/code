    public Form1()
            {
                InitializeComponent();
                Rectangle rect = new Rectangle(0, 0, 100, 200);
                Click += Form1_Click;
            }
    //associate this method to Click event Form
         private void Form1_Click(object sender, EventArgs e)
            {
                Rectangle rect = new Rectangle(0, 0, 200, 100);
                Point cursorPos = this.PointToClient(Cursor.Position);
                //you are in rectangle so message display
                if (rect.Contains(cursorPos))
                {                
                    MessageBox.Show("in");
                }
              
            }
