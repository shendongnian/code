    public void UndoCode()
        {
            IsRedoUndo = true;
            if (StackCount > 0 && RTBRedoUndo[StackCount] != null)
            {
                StackCount = StackCount - 1;
                richTextBoxPrintCtrl1.Text = RTBRedoUndo[StackCount+1];
            }
        }
