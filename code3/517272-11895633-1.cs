    public partial class SomeView : Window
    {
         public SomeView()
         {
            InitializeComponent();
            ErrorMessage.Register(this, msg =>
            {
                MessageBoxResult result = MessageBox.Show(msg.Content, msg.Caption,
                    msg.Button, msg.Icon, msg.DefaultResult, msg.Options);
                msg.ProcessCallback(result);
                // Or in your case, invoke BuildUI() method.
            });
         }
