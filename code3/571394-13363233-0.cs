    bool shouldICancelDrag = false
    
    void listBox1_PreviewDragLeave(object sender, DragEventArgs e)
    {
       shouldICancelDrag = true; 
    }
    
    private void OnQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
    {
       if(shouldICancelDrag)
       {
           e.Action = DragAction.Cancel;
           e.Handled = true;
           shouldICancelDrag = false;
       }
    }
