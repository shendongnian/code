    public static int CountSurroundingSpaces(string stringValue, char constraint)
    {
        return stringValue.SkipWhile( c => c != constraint)
                          .Skip(1)
                          .TakeWhile( c => c == ' ')
                          .Count() +
               stringValue.Reverse()
                          .SkipWhile( c => c != constraint)
                          .Skip(1)
                          .TakeWhile( c => c == ' ')
                          .Count();
    }
