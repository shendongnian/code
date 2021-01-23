    public static string RewriteChar(this string input, string replacement, int index)
    {
      // Get the array implementation
      var chars = input.ToCharArray();
      // Copy the replacement into the new array at given index
      // TODO take care of the case of to long string?
      replacement.ToCharArray().CopyTo(chars, index);
      // Wrap the array in a string represenation
      return new string(chars);
    }
