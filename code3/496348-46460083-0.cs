    public static int IndexOfNthCharacter(string str, int n, char c) {
        int index = -1;
        if (!str.Contains(c.ToString()) || (str.Split(c).Length-1 < n)) {
            return -1;
        }
        else {
            for (int i = 0; i < str.Length; i++) {
                if (n > 0) {            
                    index++;
                }
                else {
                    return index;
                }
                if (str[i] == c) {
                    n--;
                }
            }
            return index;
        }
    }
