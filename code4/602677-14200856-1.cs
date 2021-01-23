    private byte HiAndLo = 0;
    private const byte LoMask = 15;  // 00001111
    private const byte HiMask = 240; // 11110000
    public byte Lo
    {
        get
        {
           // &&&&----
           return (byte)(this.hiAndLo & LoMask);
        }
        set
        {
           if (value > LoMask) // 
           {
               // Values over 15 are too high.
               throw new OverflowException();
           }
           
           // &&&&XXXX
           // ||||----
           this.hiAndLo = (byte)((this.hiAndLo & HiMask) | value);
        }
    }
    public byte Hi
    {
        get
        {
            // &&&&XXXX >> 0000&&&&
            return (byte)((this.hiAndLo & HiMask) >> 4);
        }
        set
        {
            if (value > LoMask)
            {
                // Values over 15 are too high.
                throw new OverflowException();
            }
            // -------- << ----0000
            //             XXXX&&&&
            //             ||||||||
            this.hiAndLo = (byte)((hiAndLo & LoMask) | (value << 4 )); 
        }
    }
