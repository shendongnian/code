        public void ReplaceWord(int index, int length, string newWord)
        {
            richTextBox1.Select(index, length);
            richTextBox1.SelectedText = newWord;
            richTextBox1.Select(index, newWord.Length);
        }
        public void ReplaceWord(string oldWord, string newWord)
        {
            ReplaceWord(richTextBox1.Text.IndexOf(oldWord), oldWord.Length, newWord);
        }
