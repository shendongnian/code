    public Form1() {
      InitializeComponent();
      toolStripButton1.MouseDown += toolStripButton_MouseDown;
      toolStripButton2.MouseDown += toolStripButton_MouseDown;
      panel1.DragEnter += panel1_DragEnter;
      panel1.DragDrop += panel1_DragDrop;
    }
    void toolStripButton_MouseDown(object sender, MouseEventArgs e) {
      this.DoDragDrop(sender, DragDropEffects.Copy);
    }
    void panel1_DragEnter(object sender, DragEventArgs e) {
      e.Effect = DragDropEffects.Copy;
    }
    void panel1_DragDrop(object sender, DragEventArgs e) {
      ToolStripButton button = e.Data.GetData(typeof(ToolStripButton))
                               as ToolStripButton;
      if (button != null) {
        if (button.Equals(toolStripButton1)) {
          MessageBox.Show("Dragged and dropped Button 1");
        } else if (button.Equals(toolStripButton2)) {
          MessageBox.Show("Dragged and dropped Button 2");
        }
      }
    }
