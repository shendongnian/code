    public class BorderedTextBox : UserControl
    {
        TextBox textBox;
        public BorderedTextBox()
        {
            textBox = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(-1, -1),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right
            };
            Control container = new ContainerControl()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(-1)
            };
            container.Controls.Add(textBox);
            this.Controls.Add(container);
            DefaultBorderColor = SystemColors.ControlDark;
            FocusedBorderColor = Color.Red;
            BackColor = DefaultBorderColor;
            Padding = new Padding(1);
            Size = textBox.Size;
        }
        public Color DefaultBorderColor { get; set; }
        public Color FocusedBorderColor { get; set; }
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        protected override void OnEnter(EventArgs e)
        {
            BackColor = FocusedBorderColor;
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            BackColor = DefaultBorderColor;
            base.OnLeave(e);
        }
        protected override void SetBoundsCore(int x, int y,
            int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, textBox.PreferredHeight, specified);
        }
    }
