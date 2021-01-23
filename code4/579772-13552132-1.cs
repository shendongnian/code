    public static String toBinaryString(int n) {
        String s = "";  // you can also use a StringBuilder here
        do {
            s = (n % 2) + s;  // add to front: 0 if n is divisible by 2,
                              // 1 if n is not divisble by 2.
            n /= 2;  // divide n by 2 to obtain next digit of
                     // binary representation in next iteration
        } while (n != 0);
        return s;
    }
