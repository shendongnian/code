    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            Control TextBoxDetails;
            TextBox BehaveTextbox;
    
            private void btn_t_Click(object sender, RoutedEventArgs e)
            {
                BehaveTextbox = TextBoxDetails as TextBox;
                if (TextBoxDetails != null)
                {
                    var _CareIndex = BehaveTextbox.CaretIndex;
                    BehaveTextbox.Text = BehaveTextbox.Text.Insert(_CareIndex, "\t");
                    BehaveTextbox.Focus();
                    BehaveTextbox.CaretIndex = _CareIndex + 1;
                }
            }
    
            private void btn_s_Click(object sender, RoutedEventArgs e)
            {
                BehaveTextbox = TextBoxDetails as TextBox;
                if (TextBoxDetails != null)
                {
                    var _CareIndex = BehaveTextbox.CaretIndex;
                    BehaveTextbox.Text = BehaveTextbox.Text.Insert(_CareIndex, " ");
                    BehaveTextbox.Focus();
                    BehaveTextbox.CaretIndex = _CareIndex + 1;
                }
            }
    
            private void btn_bs_Click(object sender, RoutedEventArgs e)
            {
                BehaveTextbox = TextBoxDetails as TextBox;
    
                if (TextBoxDetails != null)
                {
    
                    string _CurrentValue = BehaveTextbox.Text;
                    var _CareIndex = BehaveTextbox.CaretIndex;
    
                    if (_CareIndex > 0)
                    {
                        string _Backspace = _CurrentValue.Remove(_CareIndex - 1, 1);
                        BehaveTextbox.Text = _Backspace;
                        BehaveTextbox.Focus();
                        BehaveTextbox.CaretIndex = _CareIndex - 1;
                    }
                }
            }
    
            private void txt_result_GotFocus(object sender, RoutedEventArgs e)
            {
                TextBoxDetails = (Control)sender;
            }
        }
