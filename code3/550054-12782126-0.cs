    public Form1()
    {
      InitializeComponent();
      dgvMain.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
      dgvMain.EditingControlShowing += dgvMain_EditingControlShowing;
    }
    void dgvMain_EditingControlShowing(object sender,
                                       DataGridViewEditingControlShowingEventArgs e)
    {
      TextBox tb = e.Control as TextBox;
      if (tb != null) {
        tb.ContextMenuStrip = new ContextMenuStrip();
        tb.KeyDown -= TextBox_KeyDown;
        tb.KeyDown += TextBox_KeyDown;
      }
    }
    void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V)) {
        e.SuppressKeyPress = true;
      }
    }
