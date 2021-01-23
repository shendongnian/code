        private static string rev(string inSent) { 
            if(inSent.IndexOf(" ") != -1) 
            { 
                int space = inSent.IndexOf(" "); 
                System.Text.StringBuilder st = new System.Text.StringBuilder(inSent.Substring(space+1)); 
                return rev(st.ToString()) + " " + inSent.Substring(0, space); 
            } 
            else 
            { 
                return inSent; 
            } 
        }
