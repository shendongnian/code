    static public class RichTextBoxExtensions
    {
        static public void ReplaceWord(this RichTextBox rtb, int index, int length, string newWord)
        {
            rtb.Select(index, length);
            rtb.SelectedText = newWord;
            rtb.Select(index, newWord.Length);
        }
        static public void ReplaceWord(this RichTextBox rtb, string oldWord, string newWord)
        {
            rtb.ReplaceWord(rtb.Text.IndexOf(oldWord), oldWord.Length, newWord);
        }
    }
