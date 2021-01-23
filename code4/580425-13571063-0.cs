        public static bool IsNullOrEmpty(String value) { 
            return (value == null || value.Length == 0); 
        }
 
        [Pure]
        public static bool IsNullOrWhiteSpace(String value) {
            if (value == null) return true;
 
            for(int i = 0; i < value.Length; i++) {
                if(!Char.IsWhiteSpace(value[i])) return false; 
            } 
            return true; 
        }
        // Trims the whitespace from both ends of the string.  Whitespace is defined by
        // Char.IsWhiteSpace. 
        // 
        [Pure]
        public String Trim() { 
            Contract.Ensures(Contract.Result<String>() != null);
            Contract.EndContractBlock();
            return TrimHelper(TrimBoth); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        private String TrimHelper(int trimType) { 
            //end will point to the first non-trimmed character on the right
            //start will point to the first non-trimmed character on the Left
            int end = this.Length-1;
            int start=0; 
            //Trim specified characters. 
            if (trimType !=TrimTail)  { 
                for (start=0; start < this.Length; start++) {
                    if (!Char.IsWhiteSpace(this[start])) break; 
                }
            }
            if (trimType !=TrimHead) { 
                for (end= Length -1; end >= start;  end--) {
                    if (!Char.IsWhiteSpace(this[end])) break; 
                } 
            }
 
            return CreateTrimmedString(start, end);
        }
