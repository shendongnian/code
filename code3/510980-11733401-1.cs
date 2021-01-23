    public class Product
    {
         public string ProductName{ get; set; }
         public int ProductSize{ get; set; }
         // etc
    }
    
    public partial class FormInventory : Form
    {
       public FormInventory()
       {
       } 
    
       public Product Product
       {
          get;
          set;
       }
    }
