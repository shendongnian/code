    internal partial class CustomMessageBox : Form
    {
        #region Fields
        public readonly MessageBoxButtons _buttons;
        #endregion
        //need to seal properties to override from derived class
        #region Constructors
        /// <summary>
        /// This constructor is required for designer support.
        /// </summary>
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        public CustomMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponent();
            Text = title;
            lblMessage.Text = message;
            _buttons = buttons;
        }
        #endregion
        #region Properties
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        #endregion
        #region private
        private void frmCustomMessageBoxLoad(object sender, EventArgs e)
        {
            lblMessage.Left = (ClientSize.Width - lblMessage.Width) / 2;
            switch(_buttons)
            {
                case MessageBoxButtons.OKCancel:
                    {
                        btnLeft.Text = @"OK";
                        btnLeft.DialogResult = DialogResult.OK;
                        btnRight.Text = @"Cancel";
                        btnRight.DialogResult = DialogResult.Cancel;
                        AcceptButton = btnLeft;
                        break;
                    }
                case MessageBoxButtons.OK:
                    {
                        btnLeft.Text = @"OK";
                        btnLeft.DialogResult = DialogResult.OK;
                        btnRight.Hide();
                        btnLeft.Left = (ClientSize.Width - btnLeft.Width) / 2;
                        AcceptButton = btnLeft;
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        btnLeft.Text = @"Yes";
                        btnLeft.DialogResult = DialogResult.Yes;
                        btnRight.Text = @"No";
                        btnRight.DialogResult = DialogResult.No;
                        AcceptButton = btnLeft;
                        break;
                    }
                default :
                    {
                        btnLeft.Hide();
                        btnRight.Hide();
                        break;
                    }
            }
            AcceptButton = btnLeft;
        }
        #endregion
    }
