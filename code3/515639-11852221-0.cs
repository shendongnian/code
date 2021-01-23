    static class Utility{
        public static void HighlightText(this RichTextBox myRtb, string word, Color color){
           int startIndex = 0;       
           while(myRtb.Text.IndexOf(word, startIndex) != -1){
               int index = myRtb.Text.IndexOf(word, startIndex);
               myRtb.Select(index, word.Length);
               myRtb.SelectionColor = color;
               startIndex = index + word.Lenght;
           }
           myRtb.SelectionStart = 0;
           myRtb.SelectionLength = 0;
        }
    }
