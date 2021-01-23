     private string ConvertToUTF(string input_text)
        {
            string _out = String.Empty;
            char[] _chars = input_text.ToCharArray();
            foreach (char c in _chars)
            {
                _out += ((Int16)c).ToString("X4");
            }
            return _out;
        }
Useage:
Console.WriteLine(ConvertToUTF("سلام"));
