    public class TextBoxEx : TextBox
    {
        public TextBoxEx()
        { }
    
        public void GoTo(int line, int column)
        {
            if (line < 1 || column < 1 || this.Lines.Length < line)
                return;
            
            this.SelectionStart = this.GetFirstCharIndexFromLine(line - 1) + column - 1;
            this.SelectionLength = 0;
        }
    
        public int CurrentColumn
        {
            get { return this.SelectionStart - this.GetFirstCharIndexOfCurrentLine() + 1; }
        }
     
        public int CurrentLine
        {
            get { return this.GetLineFromCharIndex(this.SelectionStart) + 1; }
        }
    }
