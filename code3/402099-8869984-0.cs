    public partial class CustomMessageForm : DevExpress.XtraEditors.XtraForm
    {
            private static CustomMessageForm form = new CustomMessageForm();
    
            public CustomMessageForm()
            {
                InitializeComponent();
            }
    
            private void ShowDialog(string type, string message)
            {
                form .Text = type + "Information";
                form .groupMessage.Text = type + "Information";
                form .memoEditMessage.Lines[0] = message;
                form.ShowDialog();
    
            }
    
            public static Show(string type, string message)
            {
               if(form.Visible)
                  form.Close();
               ShowDialog(type, message);
            }
    }
