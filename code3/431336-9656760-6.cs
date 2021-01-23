        /// <summary>
        /// http://www.freevbcode.com/ShowCode.asp?ID=4303
        /// </summary>
        private string ColumnLetter(int ColumnNumber)
        {
            if (ColumnNumber > 26)
            {
                return string.Format("{0}{1}", (char)(Convert.ToInt32((ColumnNumber - 1) / 26) + 64), (char)(((ColumnNumber - 1) % 26) + 65));
            }
            else
            {
                return string.Format("{0}", (char)(ColumnNumber + 64));
            }
        }
