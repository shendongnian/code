    public static class MathHelper
    {
      public static double Round(double value, int digits)
      {
        return Math.Round(value, digits, MidpointRounding.AwayFromZero);
      }
    }
