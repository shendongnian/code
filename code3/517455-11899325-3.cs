        static bool SimpleValidPostCode(string code)
        {
            if (code == null || code.Length != 4)
            {
                return false;
            }
            if ("189".Contains(code[0]))
            {
                return false;
            }
            for (var i = 1; i < 4; i++)
            {
                if (!"123456789".Contains(code[i]))
                {
                    return false;
                }
            }
            return true;
        }
