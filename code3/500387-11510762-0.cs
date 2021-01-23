    public Form1() {
      InitializeComponent();
      
      dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
      dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
    }
    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
      if (e.Control is ComboBox) {
        SendKeys.Send("{F4}");
      }
    }
