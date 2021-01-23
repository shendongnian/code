     public override short[] GetShortDataAlignedRight()
        {
            short[] ReturnArray = new short[_channels[0].Data.Length / 2];
            if (_channels[0].Bpp == 8)
            {
                Buffer.BlockCopy(_channels[0].Data, 0, ReturnArray, 0, _channels[0].Data.Length);
            }
            else
            {
                short tempData;
                int offsetHigh = 8 - (16 - _channels[0].Bpp);
                int offsetLow = (16 - _channels[0].Bpp);
                for (int i = 0, j = 0; i < _channels[0].Data.Length; i += 2, j++)
                {
                    tempData = (short)(_channels[0].Data[i] >> offsetLow);
                    tempData |= (short)(_channels[0].Data[i + 1] << offsetHigh);
                    ReturnArray[j] = tempData;
                }
            }
            return ReturnArray;
        }
