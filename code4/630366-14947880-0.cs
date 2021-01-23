    static unsafe void performPaddedBubbleSort(string s, char c, int padCount, IList<string> list) {
            s = new string(c, padCount) + s;
            bool complete = false;
            int index = 0;
            int count = 0;
            fixed (char* p = s) {
                while (count < s.Length && *p == c) {
                    while (index < s.Length) {
                        if (*(p + index) != c) {
                            // flip them
                            char tempChar = *(p + index);
                            if (index != 0)
                                *((p + index) - 1) = tempChar;
                            *(p + index) = c;
                            list.Add(new string(p));
                        }
                        
                        index++;
                    }
                    index = 0;
                    count++;
                }
            }
        }
