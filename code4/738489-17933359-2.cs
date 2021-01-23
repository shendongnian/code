    public partial class Window21 : Window
    {
      public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(MainViewModel), typeof(Window21), new PropertyMetadata(default(MainViewModel)));
    
      public MainViewModel ViewModel {
        get { return (MainViewModel)this.GetValue(ViewModelProperty); }
        set { this.SetValue(ViewModelProperty, value); }
      }
    
      public Window21() {
        this.InitializeComponent();
        this.ViewModel = new MainViewModel("TopLevel");
      }
    
      private void AddNewItemOnClick(object sender, RoutedEventArgs e) {
        double Num;
        var isNum = double.TryParse(this.tb.Text, out Num);
        //If not numerical value, warn user
        if (isNum == false) {
          MessageBox.Show("Value must be Numerical");
          return;
        }
    
        var isDuplicate = this.ViewModel.AddNewChildren(Num);
        if (isDuplicate) {
          MessageBox.Show("Sorry, the number you entered is a duplicate of a current node, please try again.");
          return;
        }
      }
    }
