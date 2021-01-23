    /// <summary>
    /// Checks to see if this cell lies on a major diagonal of a power of 2.
    /// ^[0]*[1]*[0]+$ denotes the regular expression of the binary pattern we are looking for.
    /// </summary>
    public bool IsDiagonalMajorToPowerOfTwo ()
    {
        byte [] bytes = null;
        bool moreOnesPossible = true;
        System.Numerics.BigInteger number = 0;
        number = System.Numerics.BigInteger.Abs(this.X - this.Y);
        if ((number == 0) || (number == 1)) // 00000000
        {
            return (true); // All bits are zero.
        }
        else
        {
            // The last bit should always be 0.
            if (number.IsEven)
            {
                bytes = number.ToByteArray();
                for (byte b=0; b < bytes.Length; b++)
                {
                    if (moreOnesPossible)
                    {
                        switch (bytes [b])
                        {
                            case 001: // 00000001
                            case 003: // 00000011
                            case 007: // 00000111
                            case 015: // 00001111
                            case 031: // 00011111
                            case 063: // 00111111
                            case 127: // 01111111
                            case 255: // 11111111
                            {
                                // So far so good.
                                // Carry on testing subsequent bytes.
                                break;
                            }
                            case 128: // 10000000
                            case 064: // 01000000
                            case 032: // 00100000
                            case 016: // 00010000
                            case 008: // 00001000
                            case 004: // 00000100
                            case 002: // 00000010
                            case 192: // 11000000
                            case 096: // 01100000
                            case 048: // 00110000
                            case 024: // 00011000
                            case 012: // 00001100
                            case 006: // 00000110
                            case 224: // 11100000
                            case 112: // 01110000
                            case 056: // 00111000
                            case 028: // 00011100
                            case 014: // 00001110
                            case 240: // 11110000
                            case 120: // 01111000
                            case 060: // 00111100
                            case 030: // 00011110
                            case 248: // 11111000
                            case 124: // 01111100
                            case 062: // 00111110
                            case 252: // 11111100
                            case 126: // 01111110
                            case 254: // 11111110
                            {
                                moreOnesPossible = false;
                                break;
                            }
                            default:
                            {
                                return (false);
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
            else
            {
                return (false);
            }
        }
        return (true);
    }
