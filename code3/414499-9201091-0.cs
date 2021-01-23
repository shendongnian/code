       public partial class MainWindow : IView
       {
          private readonly IViewModel _vm;
          
          public MainWindow(IViewModel vm)
          {
             _vm = vm;
             DataContext = _vm;
    
             InitializeComponent();         
          }   
    
        }
