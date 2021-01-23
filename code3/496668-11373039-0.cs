    string GiveMeABetterName (string input) {
        if (input != null
              && (input.Length == 8 || input.Length == 10)) {
            return input.Substring(input.Length - 4);
        } else {
            return "";
        }
    }
