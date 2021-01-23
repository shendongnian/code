    // Your class for which the property grid should display properties
    public class YourClass
    {
      private int? myIntValue;      // Nullable int
      private string myStringValue;
      public int? MyIntValue        // Nullable int
      {
        get { return myIntValue; }
        set { myIntValue = value; }
      }
      public string MyStringValue
      {
        get { return myStringValue; }
        set { myStringValue = value; }
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
