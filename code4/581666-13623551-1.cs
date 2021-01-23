    public partial class UserControl1 : UserControl
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            MessageBox.Show("KeyDown: " + e.KeyCode.ToString());
            base.OnKeyDown(e);
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
                return true;
            else
                return base.IsInputKey(keyData);
        }
        public UserControl1()
        {
            SetStyle(ControlStyles.Selectable, true);
            
            InitializeComponent();
        }
    }
