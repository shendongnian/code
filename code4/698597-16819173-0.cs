    public class ChildForm : Form {
        
        public MainForm MyParent { get; set; }
      
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Hoho";
            
            // Now your child can access the instance of MainForm directly
            this.MyParent.spotcall(); 
        }   
        
    }
