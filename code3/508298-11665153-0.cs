    bool Validate(string s) {
        int numDigits = s.Count(c => char.IsNumber(c));
        if (numDigits <= 7) {
            return numDigits == s.Length;
        } else {
            int numLetters = s.Count(c => char.IsLetter(c));
            return numLetters > 0 && numDigits + numLetters == s.Length;
        }
    }
