        public UInt32 getKeyCode(string Key)
        {
            Constants.KeyboardControls keynum;
            if (Enum.TryParse<Constants.KeyboardControls>(Key, true, out keynum))
            {
                return (UInt32)(keynum);
            }
            else
            {
                return new UInt32();
            }
        }
