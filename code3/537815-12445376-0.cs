    public abstract class ScannableStringBase
    {
        public abstract int Length { get; }
        
        public abstract char this[int index] { get; }
        
        public int PositionOfTheSecondWord()
        {
            int pos = 0;
            int state = 0;
            char c;
        
            int length = this.Length;
            while (pos <= length - 1)
            {
                c = this[pos];
        
                if (c == ' ' || c == '\n') // space
                {
                    if (state == 1)
                        state = 2; // 2 means the space between the first and the second word has begun
                }
                else // a letter
                    if (state == 0)
                        state = 1; // 1 means the first word has begun
                    if (state == 2)
                        return pos;
                
                pos++;
            }
        
            return -1;
        
        }
    }
