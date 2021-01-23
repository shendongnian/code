    // Your class for which the property grid should display properties
    public class YourClass
    {    
      public int? MyIntValue        // Nullable int
      {
        get;set;     
      }
      public string MyStringValue
      {
        get;set;
      }
    }
   
    public partial class Form1 : Form
    {
      private YourClass yourClass;
      // In your winform
      private void Form1_Load(object sender, EventArgs e)
      {
        yourClass = new YourClass();
        
        // Set selected object
        propertyGrid1.SelectedObject = yourClass;
      }
    }
