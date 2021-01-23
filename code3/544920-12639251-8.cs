        private Boolean IsTextAllowed(String text)
        {
            string acceptedChars = "ABCDEFabcdef";
            foreach (Char c in text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || acceptedChars.Contains(c)) continue;
                else return false;
            }
            return true;
        }
