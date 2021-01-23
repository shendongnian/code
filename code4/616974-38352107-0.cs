     class RandomString
    {
        private bool m_HasCaps;
        private bool m_HasNumbers;
        private bool m_HasSymbols;
        private int m_StringLength;
        private string characterString;
        private string randomString;
        //Set possible characters to char array rather than a string for potential future method involving chars
        private char[] lower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private char[] upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private char[] numbers = "0123456789".ToCharArray();
        private char[] symbols = "!£$%&()<>[]?#-+=".ToCharArray();
        
        /// <summary>
        /// The returned string can contain just lowercase or a mixture of upper, digits and symbols depending on params and
        /// the lenght of the string return can also be set
        /// </summary>
        /// <param name="caps">Does the string need to conatain at least 1 upper case</param>
        /// <param name="nums">does the string need to contain at least 1 numeral</param>
        /// <param name="symbols">does the string need to contain at least 1 symbol</param>
        /// <param name="length">the length of the string to return </param>
        public RandomString(bool caps, bool nums,bool symbols,int length)
        {
            m_HasCaps = caps;
            m_HasNumbers = nums;
            m_HasSymbols = symbols;
            m_StringLength = length;
        }
        public string CreatePassword()
        {
            BuildCharacterstring();
            BuildRandomString();
            return randomString;
        
        }
        //Check to see what the string must contain and add those characters to the 
        //Character string 
        private void BuildCharacterstring()
        {
            characterString = new string(lower);
            if (m_HasCaps)
            {
                string upperString = new string(upper);
                characterString += upperString;
            }
            if (m_HasNumbers)
            {
                string numberString = new string(numbers);
                characterString += numberString;
            }
            if (m_HasSymbols)
            {
                string symbolString = new string(symbols);
                characterString += symbolString;
            }
        }
        //
        private void BuildRandomString()
        {
            Random rdm = new Random();
            bool validPassword = false;
            while (validPassword == false)
            {
                //blank the string before each run otherwise you end up with double the characters
                randomString = "";
                for (int x = 0; x < m_StringLength; x++)
                {
                    //select a char from the password character string
                    int place = rdm.Next(0, characterString.Length);
                    char character = characterString[place];
                    randomString += character;
                }
                //Check that the password has the appropriate characters
                validPassword = CheckParams();
            }
        }
        //checks that each required preference is met and that the string includes at least 1 of what 
        //is selected. If the parameter is not required ie symbols are not required set it to true to pass
        //the test anyway.
        private bool CheckParams()
        {
            bool capsPassed;
            bool numeralPassed;
            bool symbolPassed;
            bool lowerPassed;
            //If caps are not required set to true to pass the test automatically
            if(m_HasCaps == false)
            {
                capsPassed = true;
            }
            else
            {
                //check if the password contains an uppercase letter
                capsPassed = (randomString.Any(char.IsUpper)) ? true : false;
            }
            if(m_HasNumbers == false)
            {
                numeralPassed = true;
            }
            else
            {
                numeralPassed = (randomString.Any(char.IsDigit)) ? true : false;
            }
            if(m_HasSymbols == false)
            {
                symbolPassed = true;
            }
            else
            {
                symbolPassed = (randomString.Any(char.IsSymbol)) ? true : false;
            }
            lowerPassed = (randomString.Any(char.IsLower)) ? true : false;
            //All 4 must pass to return true and stop password generation
            if (capsPassed && numeralPassed && symbolPassed &&lowerPassed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
