    public bool ConformsToPattern(System.Numerics.BigInteger number) {
        bool moreOnesPossible = true;
        if (number == 0) {
            return true;
        }
        else {
            byte[] bytes = number.ToByteArray();
            if ((bytes[bytes.Length - 1] & 1) == 1) {
                return false;
            }
            else {
                for (byte b = 0; b < bytes.Length; b++) {
                    if (moreOnesPossible) {
                        switch (bytes[b]) {
                            case 1:
                            case 3:
                            case 7:
                            case 15:
                            case 31:
                            case 63:
                            case 127:
                            case 255:
                                continue;
                            default:
                                switch (bytes[b]) {
                                    case 128:
                                    case 192:
                                    case 224:
                                    case 240:
                                    case 248:
                                    case 252:
                                    case 254:
                                        moreOnesPossible = false;
                                        continue;
                                    default:
                                        return false;
                                }
                        }
                    }
                    else {
                        if (bytes[b] > 0) { return (false); }
                    }
                }
            }
        }
        return true;
    }
