    public static class Extensions
    {
       public static bool IsEqualOrBothNullOrEmpty(this string firstValue,
                               string secondValue)
       {
          return string.IsNullOrEmpty(firstValue) &&
                   string.IsNullOrEmpty(secondValue)
                      || firstValue.ToLower() == secondValue.ToLower();
        }
    }
