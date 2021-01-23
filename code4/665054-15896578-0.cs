    public partial class frmSettings : Form
    {
      public frmSettings()
      {
        InitializeComponent();
      }
    
      public string[] GetProducts()
      {
        var products = new List<string>
          {
            "Apple", "Banana"
          };
          
        return products.ToArray();
      }
    }
