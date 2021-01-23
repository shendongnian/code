    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class SampleTextBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int EM_SETMARGINS = 0xd3;
        private const int EC_LEFTMARGIN = 1;
        private Label label;
        public SampleTextBox() : base()
        {
            label = new Label() { Text = "http://", Dock = DockStyle.Left, AutoSize = true };
            this.Controls.Add(label);
        }
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; if (IsHandleCreated) SetMargin(); }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetMargin();
        }
        private void SetMargin()
        {
            SendMessage(this.Handle, EM_SETMARGINS, EC_LEFTMARGIN, label.Width);
        }
    }
