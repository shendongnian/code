        private const byte InverseBlueMask = 7; // 00000111
        private const byte InverseGreenMask = 3; // 00000011
        private const byte InverseRedMask = 7; //  00000111
        public void getEachBitOfMessage(byte byteToManipulate, int colour)
        {
            byte value = 0;
            if (countToByte == 3)
            {
                byte blueAreaInTotal = 0;
                byte greenAreaInTotal = 0;
                byte redAreaInTotal = 0;
                byte total = 0; 
                redAreaInTotal = (byte)(redCount);
                blueAreaInTotal = (byte)(blueCount << 5);
                greenAreaInTotal = (byte)(greenCount << 3);
                total = (byte)(total | redAreaInTotal); 
                total = (byte)(total | blueAreaInTotal);
                total = (byte)(total | greenAreaInTotal); 
                convertToChar(total);
                
                redCount = 0;
                blueCount = 0;
                greenCount = 0; 
                countToByte = 0; 
            }
            if (colour == BLUE)
            {
                value = (byte)(byteToManipulate & InverseBlueMask);
                blueCount = value; 
            }
            else if (colour == GREEN)
            {
                value = (byte)(byteToManipulate & InverseGreenMask);
                greenCount = value; 
            }
            else if (colour == RED)
            {
                value = (byte)(byteToManipulate & InverseRedMask);
                redCount = value; 
            }
            countToByte++; 
        }
