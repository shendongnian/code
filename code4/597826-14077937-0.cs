    class ExcelTable
    {
        public const int SignificantCharsInVariableName = 10;
    
        private string[] columnNames = null;
        private string[,] data = null;
    
        private string[] DefineColumnNames(string[,] R)
        {
            string[] names = new string[R.GetLength(1)];
    
            for (int i = 0; i < R.GetLength(1); i++)
            {
                names[i] = R[0, i].Trim();
            }
    
            return names;
        }
    
    
        public string GetValue(int row, string varName)
        {
            string s;
            int col;
    
            try
            {
                col = GetColumn(varName);
    
                s = data[row, col].Trim();
            }
            catch (Exception)
            {
                s = "???";
            }
    
            return s;
        }
    
    
        private int GetColumn(string name)
        {
            return GetColumn(name, this.columnNames, obligatory: true);
        }
    
        private int GetColumn(string name, string[] names, bool obligatory = false)
        {
            string nameStart;
    
            //  first try perfect match
            for (int i = 0; i < names.Length; i++)
                if (names[i].Equals(name))
                    return i;
    
            //  2nd try to match the significant characters only
            nameStart = name.PadRight(SignificantCharsInVariableName, ' ').Substring(0, SignificantCharsInVariableName);
            for (int i = 0; i < names.Length; i++)
                if (names[i].StartsWith(nameStart))
                    return i;
    
            if (obligatory)
            {
                throw new Exception("Undefined Excel sheet column '" + name + "'");
            }
    
            return -1;
        }
    
    }
