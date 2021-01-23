    class Parser
    {
            public bool IsInt { get; set; }
            public int Val { get; set; }
            public Parser(string val)
            {
                int outVal;
                IsInt = int.TryParse(val, out outVal);
                if (IsInt)
                {
                    Val = outVal;
                }
            }
    }
