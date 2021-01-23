    this.DragEnter += new System.Windows.Forms.DragEventHandler(this.XmlEditControl_DragEnter);
    this.DragDrop += new System.Windows.Forms.DragEventHandler(this.XmlEditControl_DragDrop);
    private void XmlEditControl_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.All;
    }
    private void XmlEditControl_DragDrop(object sender, DragEventArgs e)
    {
        MessageBox.Show("I dropped");
    }
