    public static Boolean isNumber(String test) {
            char[] chars = test.ToCharArray();
            foreach(char c in chars) {
                int charCode = (int)c;
                if(charCode < 48 || charCode > 57)
                    return false;
            }
            return true;
        }
