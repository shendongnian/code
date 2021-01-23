    bool shouldICancelDrag = false
    
    //changed this to be previewDrop on the Window (not the listbox)
    void window1_PreviewDrop(object sender, DragEventArgs e)
    {
       //check if the item was dropped on something other than the listbox
       //you may need to toy with using e.Source instead (break and see what you're getting via the debugger)
       if (! (e.OriginalSource is ListBox))
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
