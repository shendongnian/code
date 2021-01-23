    public partial class Form1 : Form
    {
       // Create Storage
       List<string> store = new List<string>();
    
       private void button1_click(object sender, EventArgs e)
       {
           // Will add the input of the textbox to list each time button clicked.
           store.Add(textbox1.Text);
       }
    
       private void button2_click(object sender, EventArgs e)
       {
           // Logic to Add the items.
       }
    }
