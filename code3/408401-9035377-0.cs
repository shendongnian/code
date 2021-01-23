    string[] handle = originalString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            List<string> hexa = new List<string>();
            for (var a = 1; a <= handle.Count() - 1; a++)
            {
                if (Regex.IsMatch(handle[a], @"^\s\s5"))
                {
                    hexa.Add(handle[a + 1]);
                }
            }
            List<int> HexaToInt = new List<int>();
            foreach (string valueHexa in hexa)
            {
                int intHexaValue = int.Parse(valueHexa, System.Globalization.NumberStyles.HexNumber);
                HexaToInt.Add(intHexaValue);
            }
            int maximumHexa = HexaToInt.Max();
            string hexValue = maximumHexa.ToString("X");
