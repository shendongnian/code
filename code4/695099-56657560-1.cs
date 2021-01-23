    public class SentenceSplitResult
    {
        public string word;
        public bool isAWord;
    }
    public class StringsHelper
    {
        private readonly List<SentenceSplitResult> outputList = new List<SentenceSplitResult>();
        private readonly string input;
        public StringsHelper(string input)
        {
            this.input = input;
        }
        
        public List<SentenceSplitResult> GetSplitSentence()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (String.IsNullOrEmpty(input)) {
                    Logger.Log(new ArgumentNullException(), "GetSplitSentence - input is null or empy");
                    return outputList;                    
                }
                bool isAletter = IsAValidLetter(input[0]);
                // Each char i checked if is a part of a word.
                // If is YES > I can store the char for later
                // IF is NO > I Save the word (if exist) and then save the punctuation
                foreach (var _char in input)
                {
                    isAletter = IsAValidLetter(_char);
                    if (isAletter == true)
                    {
                        sb.Append(_char);
                    }
                    else
                    {
                        SaveWord(sb.ToString());
                        sb.Clear();
                        SaveANotWord(_char);                        
                    }
                }
                SaveWord(sb.ToString());
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return outputList;
        }
        private static bool IsAValidLetter(char _char)
        {
            if ((Char.IsPunctuation(_char) == true) || (_char == ' ') || (Char.IsNumber(_char) == true))
            {
                return false;
            }
            return true;
        }
        private void SaveWord(string word)
        {
            if (String.IsNullOrEmpty(word) == false)
            {
                outputList.Add(new SentenceSplitResult()
                {
                    isAWord = true,
                    word = word
                });                
            }
        }
        private void SaveANotWord(char _char)
        {
            outputList.Add(new SentenceSplitResult()
            {
                isAWord = false,
                word = _char.ToString()
            });
        }
