    public static double R(double x)
    {
        // markup to nearest 5
        return (((int)(x / 5)) * 5) + ((x % 5) > 0 ? 5 : 0);
    }
