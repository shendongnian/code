    public char decode_char(char input, char[] array1, char[] array2)
    {
      return array1.Contains(input) 
         ? array2[array1.IndexOf(input)]
         : array2.Contains(input)
            ? array1[array2.IndexOf(input)];
            : input;         
    }
