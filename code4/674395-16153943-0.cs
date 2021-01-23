public partial class MainPage : PhoneApplicationPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private async void Button_LogIn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Service1SoapClient web_service = new Service1SoapClient();
            string answer = await web_service.LogInAsync(TextBox_Username.Text, TextBox_Password.Password);
            if (answer.ToLower().Equals("success"))
            {
                NavigationService.Navigate(new Uri("/Authenticated.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("The log-in details are invalid!");
            }
        catch (<ExceptionType> e)
        {
            // ... handle exception here
        }
    }
}
Note that one of the side-benefits of `async` and `await` is that they allow you to write your code logically, including your exception handling code which, prior to `async` and `await` was hard to get right!
