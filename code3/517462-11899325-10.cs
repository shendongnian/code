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
I only can do it with : if, if … else, if … else if … else constructs Nested ifs CASE and switch constructs
