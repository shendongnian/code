       public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                try
                {
                  var engine = new FileHelperEngine<Customer>();
                  // To Read Use:
                  Customer[] res = engine.ReadFile(@"c:\yourpath\f1.txt");
                  // To Write Use:
                  engine.WriteFile(@"c:\yourpath\f2.txt", res);
                }
                catch(Exception ex)
                {
                  MessageBox.Show(ex.Message);
                }
            }
        }
