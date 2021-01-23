    public static class StringExtentions
    {
        private static string _invalidUserInput = string.Empty;
        private static string _PrinatbleInvalidUserInput = string.Empty;
        public static string InvalidUserInput
        {
            get
            {
                if (_invalidUserInput == string.Empty)
                {
                    _invalidUserInput = new string(Path.GetInvalidFileNameChars()
                          .Concat(Path.GetInvalidPathChars())
                          .Distinct()
                          .ToArray());
                }
                return _invalidUserInput;
            }
        }
        public static string GetPrinatbleInvalidUserInput
        {
            get
            {
                if (_PrinatbleInvalidUserInput == string.Empty)
                {
                    _PrinatbleInvalidUserInput = new string(InvalidUserInput.Where(x => !char.IsControl(x)).ToArray());
                }
                return _PrinatbleInvalidUserInput;
            }
        }
        public static bool IsValidUserInput(this string str)
        {
            return !str.Any(c => InvalidUserInput.Contains(c));
        }
    }
