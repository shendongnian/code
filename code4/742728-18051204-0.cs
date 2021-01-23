    // These are the different formattings you have
    public enum Formatings
        {
            Bold, Italic, Underline, Undefined
        }
        // This will store the current format
        private Dictionary<Formatings, bool> m_CurrentFormat;
        // This will store which string translates into which format
        private Dictionary<string, Formatings> m_FormatingEncoding;
        public void Init()
        {
            m_CurrentFormat = new Dictionary<Formatings, bool>();
            foreach (Formatings format in Enum.GetValues(typeof(Formatings)))
            {
                m_CurrentFormat.Add(format, false);
            }
            m_FormatingEncoding = new Dictionary<string, Formatings>
                                      {{"**", Formatings.Bold}, {"'", Formatings.Italic}, {"\\", Formatings.Underline}};
        }
        public void ParseFormattedText(string p_text)
        {
            StringBuilder currentWordBuilder = new StringBuilder();
            int currentIndex = 0;
            while (currentIndex < p_text.Length)
            {
                Formatings currentFormatSymbol;
                int shift;
                if (IsFormatSymbol(p_text, currentIndex, out currentFormatSymbol, out shift))
                {   
                    // This is the current word you need to insert                 
                    string currentWord = currentWordBuilder.ToString();
                    // This is the current formatting status --> m_CurrentFormat
                    // This is where you can insert your code and add the word you want to the .docx
                    currentWordBuilder = new StringBuilder();
                    currentIndex += shift;
                    m_CurrentFormat[currentFormatSymbol] = !m_CurrentFormat[currentFormatSymbol];
                }
                currentWordBuilder.Append(p_text[currentIndex]);
                currentIndex++;
            }
        }
        // Checks if the current position is the begining of a format symbol
        // if true - p_currentFormatSymbol will be the discovered format delimiter
        // and p_shift will denote it's length
        private bool IsFormatSymbol(string p_text, int p_currentIndex, out Formatings p_currentFormatSymbol, out int p_shift)
        {
            // This is a trivial solution, you can do better if you need
            string substring = p_text.Substring(p_currentIndex, 2);
            foreach (var formatString in m_FormatingEncoding.Keys)
            {
                if (substring.StartsWith(formatString))
                {
                    p_shift = formatString.Length;
                    p_currentFormatSymbol = m_FormatingEncoding[formatString];
                    return true;
                }
            }
            p_shift = -1;
            p_currentFormatSymbol = Formatings.Undefined;
            return false;
        }
