    public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < gbxButtonType.Controls.Count; i++)
            {
                RadioButton rdb = (RadioButton)gbxButtonType.Controls[i];
                rdb.CheckedChanged += new System.EventHandler(gbxButtonType_CheckedChanged);
            }
            for (int i = 0; i < gbxIconType.Controls.Count; i++)
            {
                RadioButton rdb = (RadioButton)gbxIconType.Controls[i];
                rdb.CheckedChanged += new System.EventHandler(gbxIconType_CheckedChanged);
            }
        }
    private void gbxIconType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdbAsterisk)
            {
                iconType = MessageBoxIcon.Asterisk;
            }
            else if (sender == rdbError)
            {
                iconType = MessageBoxIcon.Error;
            }
            ...
            else
            {
                iconType = MessageBoxIcon.Warning;
            }
       }
