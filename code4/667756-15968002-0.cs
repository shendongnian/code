    <TextBox x:Name="tb" Grid.Row="1" LostFocus="Tb_OnLostFocus"/>
    <Button x:Name="btn" Click="Btn_OnClick" />
     public partial class MainPage : PhoneApplicationPage
    {
        private bool flag;
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            flag = true;
        }
        private void Tb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!flag) return;
            tb.Focus();
            flag = false;
        }
    }
