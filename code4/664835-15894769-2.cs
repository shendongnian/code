        //Holds Redos/Undos
    public string[] RTBRedoUndo;
        //Holds the position in Redo/Undo Array
    public int StackCount;
        //Old RTB Length
    public int OldLength;
        //Save RichTextBox text after 5 new characters
    public int ChangeToSave = 5;
    
    public void RTBTextChanged()
    {
        if (RichTextBox1.Length - OldLength >= ChangeToSave | RichTextBox1.Length - OldLength <= ChangeToSave) {
            StackCount += 1;
            RTBRedoUndo[StackCount] = RichTextBox1.Text;
        }
    }
    
    public void Undo()
    {
        if (RTBRedoUndo[StackCount - 1 != null]) {
            StackCount -= 1;
            RichTextBox1.Text = RTBRedoUndo[StackCount];
        }
    }
    
    public void Redo()
    {
        if (RTBRedoUndo[StackCount + 1 != null]) {
            StackCount += 1;
            RichTextBox1.Text = RTBRedoUndo[StackCount];
        }
    }
