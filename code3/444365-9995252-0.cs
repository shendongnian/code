    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        HandleMouseDown(listbox1);
    }
    private void listBox2_DragEnter(object sender, DragEventArgs e)
    {
        HandleDragEnter( e );
    }
    private void listBox2_DragDrop(object sender, DragEventArgs e)
    {
        HandleDragDrop( listBox1, listBox2, e );
    }
    private void listBox2_MouseDown(object sender, MouseEventArgs e)
    {
        HandleMouseDown(listBox2);
    }
    private void listBox1_DragEnter(object sender, DragEventArgs e)
    {
        HandleDragEnter( e );
    }
    private void listBox1_DragDrop(object sender, DragEventArgs e)
    {
        HandleDragDrop( listBox2, listBox1, e );
    }
    private void HandleMouseDown( ListBox listBox )
    {
        listBox.DoDragDrop(listBox.SelectedItem.ToString(), DragDropEffects.Move);
    }
    private void HandleDragEnter( DragEventArgs e )
    {
        e.Effect = e.AllowedEffect;
    }
    private void HandleDragDrop( ListBox src, ListBox dst, DragEventArgs e )
    {
        dst.Items.Add( e.Data.GetData(DataFormats.Text) );
        src.Items.Remove( src.SelectedItem.ToString() );
    }
