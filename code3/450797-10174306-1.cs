     public partial class FormReceiver : Form
      {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
    
        private static readonly int WM_REFRESH_CONFIGURATION = RegisterWindowMessage("WM_REFRESH_CONFIGURATION");
    
        public FormReceiver()
        {
          InitializeComponent();
        }
    
        protected override void WndProc(ref Message m)
        {
          if (m.Msg == WM_REFRESH_CONFIGURATION)
          {
            lblMessageReceived.Text = "Refresh message recevied : " + DateTime.Now.ToString();
          }
          else
          {
            base.WndProc(ref m);
          }
        }
      }
