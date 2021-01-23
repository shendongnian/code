     [System.Runtime.InteropServices.ComVisible(false)]
        public StringBuilder AppendLine() {
            Contract.Ensures(Contract.Result<stringbuilder>() != null);
            return Append(Environment.NewLine);
        }
 
        [System.Runtime.InteropServices.ComVisible(false)]
        public StringBuilder AppendLine(string value) {
            Contract.Ensures(Contract.Result<stringbuilder>() != null);
            Append(value);
            return Append(Environment.NewLine);
        }
