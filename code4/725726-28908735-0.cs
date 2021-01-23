    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    namespace CoolControls
    {
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))] 
    public partial class CheckGroup : Control
    {
        private int _CheckBoxSideLength;
        private Rectangle _CheckBoxBorderRectangle;
        private bool _Focused = false;
        private bool _Checked;
        private CheckBoxState _CheckedState = CheckBoxState.UncheckedNormal;
        private int _ExpandedHeight;
        [Category("Behavior")]
        [Description("Get or set whether the checkbox is checked.")]
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                SetCheckedState(value);
            }
        }
        
        public CheckGroup()
        {
            InitializeComponent();
            InitControl();
        }
        private void InitControl()
        {
            _CheckBoxSideLength = 15;
            _Checked = true;
            _Focused = false;
            _CheckBoxBorderRectangle = new Rectangle(0, 0, _CheckBoxSideLength - 1, _CheckBoxSideLength - 1);
        }
        private void SetCheckedState(bool pToChecked)
        {
            _Checked = pToChecked;
            if (_Checked)
            {
                _CheckedState = CheckBoxState.CheckedNormal;
                this.Height = _ExpandedHeight;
            }
            else
            {
                _CheckedState = CheckBoxState.UncheckedNormal;
                this.Height = _CheckBoxSideLength;
            }
            foreach (Control c in this.Controls)
            {
                c.Enabled = _Checked;
            }
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            GroupBoxRenderer.DrawGroupBox(g, ClientRectangle, "   " + this.Text, this.Font, this.ForeColor, TextFormatFlags.Left, GroupBoxState.Normal);
            CheckBoxRenderer.DrawCheckBox(g, ClientRectangle.Location, _CheckBoxBorderRectangle, "", null, TextFormatFlags.Left, _Focused, _CheckedState);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_Checked)
            {
                _ExpandedHeight = this.Size.Height;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Location.Y <= _CheckBoxSideLength)
            {
                SetCheckedState(!_Checked);
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _Focused = true;
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _Focused = false;
            Invalidate();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                SetCheckedState(!_Checked);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
    }
