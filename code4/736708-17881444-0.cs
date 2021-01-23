    using System.Windows.Forms;
    
    public partial class Form8 : Form
    {
      public Form8() // This parameterless constructor is required by the WinForms Designer
      {
        InitializeComponent();
      }
      
      public Form8(string someValue) : this() // Constructor chaining
      {
        // Do something with someValue here
      }
    }
