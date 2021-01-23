    public partial class Main : Form
    
            {
                public partial void function1()
                {
                    doing_stuff_here();
                }
    
                private void button1_Click(object sender, EventArgs e)
                {
                    var update = new UpdateDialog();
                    update.ShowDialog();
                }   
            }
    
    public partial class UpdateDialog : Form
            {
                public partial void function1();
                private void button2_Click(object sender, EventArgs e)
                {
                function1();
                }
            }
