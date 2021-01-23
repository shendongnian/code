        static bool ValidPostCode(string code)
        {
            if (code == null || code.Length != 4)
            {
                return false;
            }
            var characters = code.ToCharArray();
            if (characters.Any(character => !Char.IsNumber(character)))
            {
                return false;
            }
            if ("189".Contains(characters.First()))
            {
                return false;
            }
            return true;
        }
