        static string FetchRegister(string Source, int Max, int StartIndex)
        {
            string Register = string.Empty;
            int RegisterIndex = 0;
            for (int i = 0; i < Source.Length; i++)
            {
                if (char.IsNumber(Source[i]))
                {
                    if (RegisterIndex >= StartIndex)
                    {
                        Register += Source[i].ToString();
                        if (Register.Length == Max)
                        {
                            return Register;
                        }
                    }
                    RegisterIndex += 1;
                }
            }
            return Register;
        }
