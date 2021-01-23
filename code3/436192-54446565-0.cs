        public  bool MojTestPalindrome (string word)
        {
            bool yes = false;
            
            char[]test1 = word.ToArray();
            char[] test2 = test1.Reverse().ToArray();
            for (int i=0; i< test2.Length; i++)
            {
                if (test1[i] != test2[test2.Length - 1 - i])
                {
                    yes = false;
                    break;
                }
                else {   
                    yes = true;
                                    
                
                }
            }
            if (yes == true)
            {
                return true;
            }
            else
                return false;                
        }
    
