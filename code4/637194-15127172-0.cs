        class Program
        {
            static void Main(string[] args)
            {
                string stringFromTextBox = 
    @"  int maxLC = 1; //maxLineCount - should be public
        private void InstructionsSyncTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int linecount = InstructionsSyncTextBox.GetLineFromCharIndex(InstructionsSyncTextBox.TextLength) + 1;
            if (linecount != maxLC)
            {
                InstructionsLineNumberSyncTextBox.Clear();
                for (int i = 1; i < linecount + 1; i++)
                {
                    InstructionsLineNumberSyncTextBox.AppendText(Convert.ToString(i) + ""\n"");
                }
                maxLC = linecount;
            }
        }";
                Regex r = new Regex("\r", RegexOptions.Multiline);
                int lines = r.Matches(stringFromTextBox).Count;
                //You'll need to run this line every time the user presses a key
    
            }
        }
