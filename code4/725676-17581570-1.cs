    public partial class MessageForm : Form
    {
        public MessageForm(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }
        public static DialogResult Show(string message, string title = "")
        {
            var form = new MessageForm(message);
            form.Text = title;
            return form.ShowDialog();
        }
    }
