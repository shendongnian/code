    class Program
    {
        static void Main()
        {
            var strMatch = new string[]
                          {
                              // Lines that should match:
                              "ABCDEFGHIJKLZ",
                              "A           Z",
                              "AB          Z",
                              "A     G     Z",
                              "AB    G     Z",
                              "ABCDEF      Z",
                              "ABCDEFG     Z",
                              "A     GHIJKLZ",
                              "AB    GHIJKLZ",
                          };
            var strNotMatch = new string[]
                          {
                              // Lines that should not match:
                              "AB D        Z",
                              "AB D F      Z",
                              "AB   F      Z",
                              "A     G I   Z",
                              "A     G I  LZ",
                              "A     G    LZ",
                              "AB   FG    LZ",
                              "AB D FG     Z",
                              "AB   FG I   Z",
                              "AB D FG i   Z",
                             
                              // The following 3 should not match but do.
                              "AB   FG     Z",
                              "AB   FGH    Z",
                              "AB  EFGH    Z",
                          };
            var pattern = @"
                    ^A
                    (?<=^.{1})  (?<name1>([ ]{5}|(?>[A-Z]{1,5})[ ]{0,4}))  (?=.{7}$)
                    (?<=^.{6})  (?<name2>([ ]{6}|(?>[A-Z]{1,6})[ ]{0,5}))  (?=.{1}$)
                    Z$
                    ";
            foreach (var eachStrThatMustMatch in strMatch)
            {
                var match = Regex.Match(eachStrThatMustMatch,
                    pattern, RegexOptions.IgnorePatternWhitespace);
                if (!match.Success)
                    throw new Exception("Should match.");
            }
            foreach (var eachStrThatMustNotMatch in strNotMatch)
            {
                var match = Regex.Match(eachStrThatMustNotMatch,
                    pattern, RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                    throw new Exception("Should match.");
            }
        }
    }
