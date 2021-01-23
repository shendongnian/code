    // The parameter [number] will NEVER be negative.
    public static bool ConformsToPattern (System.Numerics.BigInteger number)
    {
        byte [] bytes = null;
        bool moreOnesPossible = true;
        bool foundFirstOne = false;
        if (number == 0) // 00000000
        {
            return (true); // All bits are zero.
        }
        else
        {
            bytes = number.ToByteArray();
            if ((bytes [bytes.Length - 1] & 1) == 1)
            {
                return (false);
            }
            else
            {
                for (byte b=0; b < bytes.Length; b++)
                {
                    if (moreOnesPossible)
                    {
                        if(!foundFirstOne)
                        {
                            if
                            (
                                (bytes [b] == 1) // 00000001
                                || (bytes [b] == 3) // 00000011
                                || (bytes [b] == 7) // 00000111
                                || (bytes [b] == 15) // 00001111
                                || (bytes [b] == 31) // 00011111
                                || (bytes [b] == 63) // 00111111
                                || (bytes [b] == 127) // 01111111
                                || (bytes [b] == 255) // 11111111
                            )
                            {
                                foundFirstOne = true;
                                // So far so good. Continue to the next byte with
                                // a possibility of more consecutive 1s.
                            }
                            else if
                            (
                                (bytes [b] == 128) // 10000000
                                || (bytes [b] == 192) // 11000000
                                || (bytes [b] == 224) // 11100000
                                || (bytes [b] == 240) // 11110000
                                || (bytes [b] == 248) // 11111000
                                || (bytes [b] == 252) // 11111100
                                || (bytes [b] == 254) // 11111110
                            )
                            {
                                moreOnesPossible = false;
                            }
                            else
                            {
                                return (false);
                            }
                        }
                        else
                        {
                            if(bytes [b] != 255) // 11111111
                            {
                                if
                                (
                                    (bytes [b] == 128) // 10000000
                                    || (bytes [b] == 192) // 11000000
                                        || (bytes [b] == 224) // 11100000
                                    || (bytes [b] == 240) // 11110000
                                    || (bytes [b] == 248) // 11111000
                                    || (bytes [b] == 252) // 11111100
                                    || (bytes [b] == 254) // 11111110
                                )
                                {
                                    moreOnesPossible = false;
                                }
                            }                            
                        }
                    }
                    else
                    {
                        if (bytes [b] > 0)
                        {
                            return (false);
                        }
                    }
                }
            }
        }
        return (true);
    }
