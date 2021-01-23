    if (rResponse.ErrorCode[0] == 0x20)
            {
                switch (rResponse.ErrorCode[1])
                {
                    case 0x03:
                        ErrorMsg = "COMM_FRAME_ERROR";
                        break;
                    case 0x04:
                        ErrorMsg = "JAM";
                        break;
                    case 0x05:
                        ErrorMsg = "NO_CARD";
                        break;
                    default:
                        throw new InvalidOperationException();
                        break;
                }
            }
