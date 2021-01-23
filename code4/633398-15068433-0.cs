    using System.Collections.Generic;
    public partial class MainWindow {
      public MainWindow() {
        Current = new ConcreteViewModel {
          Products = {
            new Product(),
            new Product()
          }
        };
        InitializeComponent();
      }
      public ViewModelBase Current { get; set; }
    }
    public class ViewModelBase { }
    public class ConcreteViewModel : ViewModelBase {
      public ConcreteViewModel() {
        Products = new List<Product>();
      }
      public List<Product> Products { get; private set; }
    }
    public class Product {
      public string ProductName { get { return "Name1"; } }
    }
