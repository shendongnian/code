    public class TextBoxManager
    {
    
        public List<Tuple<TextBox, TextBox>> LowerHigherPairs { get; set; }
    
    
        public TextBoxManager()
        {
            LowerHigherPairs = new List<Tuple<TextBox, TextBox>>();
        }
    
    
        public void RegisterTextBoxes(TextBox lower, TextBox higher)
        {
            lower.Leave += TextBoxFocusLost;
            higher.Leave += TextBoxFocusLost;
            LowerHigherPairs.Add(new Tuple<TextBox, TextBox>(lower, higher));
            
        }
    
    
    
        public void TextBoxFocusLost(object sender, EventArgs e)
        {
    
            TextBox senderBox = sender as TextBox;
    
            Tuple<TextBox, TextBox> matchingPair = LowerHigherPairs.Find(x => x.Item1 == senderBox || x.Item2 == senderBox);
    
            if (matchingPair != null)
            {
    
                if (matchingPair.Item1 == senderBox)
                {
                    //We know we should compare with the value in Item2.Text
                }
                else
                {
                    //We know we should compare with the value in Item1.Text
                }
    
            }
    
        }
    
    
    }
