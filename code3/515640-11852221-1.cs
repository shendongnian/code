    static class Utility{
        public static void HighlightText(this RichTextBox myRtb, string word, Color color){  
           int s_start = myRtb.SelectionStart;
           int startIndex = 0;
     
           while(myRtb.Text.IndexOf(word, startIndex) != -1){
               int index = myRtb.Text.IndexOf(word, startIndex);
               myRtb.Select(index, word.Length);
               myRtb.SelectionColor = color;
               startIndex = index + word.Length;
           }
           myRtb.SelectionStart = s_start;
           myRtb.SelectionLength = 0;
           myRtb.SelectionStart = Color.Black;
        }
    }
