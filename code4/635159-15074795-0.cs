    public class SubProduct(Product)
    {
      public SubProduct()
      {
          ColorChanged += new ProductColorChangedEventHandler(color_changed);
      }
    
      private color_changed(object sender, EventArgs e)
      {
          //do stuff
      }
    }
