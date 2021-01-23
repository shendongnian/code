    protected bool CheckIfPalindrome(string text)
    {
        if (text != null)
        {
            string strToUpper = Text.ToUpper();
            char[] toReverse = strToUpper.ToCharArray();
            Array.Reverse(toReverse );
            String strReverse = new String(toReverse);
            if (strToUpper == toReverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
