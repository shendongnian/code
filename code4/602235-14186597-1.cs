    using System.Linq;
    public static string InvalidUserInput
    {
        get 
        {
            return new string(Path.GetInvalidFileNameChars()
                      .Concat(Path.GetInvalidPathChars())
                      .Distinct()
                      .ToArray());
        }
    }
