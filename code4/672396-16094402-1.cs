    // Option 1 : (New Instance)
    public class Form2()
    {
       Form2_Load(object sender, EventArgs e)
       { 
         // Create new instance of Form1
         Form1 form1 = new Form1();
         form1.MyForm1Method();
       }
    } 
    //Option 2 : (Static)
     public class Form2()
    {
       Form2_Load(object sender, EventArgs e)
       { 
         // Method is static in Form1 (The class would be static too)
         Form1.MyForm1Method();
       }
    } 
    // Option 3 (Event Subscribtion)
    //Form1:
    private void StartForm2Button_Click(object sender, EventArgs e)
    {
        Form2 form2 = new Form2();
        form2.SomethingHappened += Form2_SomethingHappened;
        form2.Show();
    }
    
    private Form2_SomethingHappened(object sender, EventArgs e)
    {
        Form2 form2 = (Form2)sender;
        string data = form2.Data;
        // create node
        AddNode(node);
    }
    //Form2:
    public event EventHandler SomethingHappened;
    
    public string Data
    {
       get { return textBoxData.Text; }
    }
    
    private void SomeButton_Click(object sender, EventArgs e)
    {
        if (SomethingHappened != null)
            SomethingHappened(this, EventArgs.Empty);
    }
