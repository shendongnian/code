    private byte convertToDecimal (string binary) {
        int i = 0;
        int byte = 0;
        while (i < s.Length) {
            if (s.Substring(s.Length - 1 - i, 1).Equals("1")) {
                sum += (byte)Math.Pow(2, i);
            }
            i++;
        }
        return sum;
    }
