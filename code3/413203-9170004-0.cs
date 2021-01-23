    // Synchronous version for comparison.
    public static string Reverse(string s)
    {
      Contract.Requires(s != null);
      Contract.Ensures(Contract.Result<string>() != null);
      return ...;
    }
    // First wrapper takes care of preconditions (synchronously).
    public static Task<string> ReverseAsync(string s)
    {
      Contract.Requires(s != null);
      return ReverseWithPostconditionAsync(s);
    }
    // Second wrapper takes care of postconditions (asynchronously).
    private static async Task<string> ReverseWithPostconditionAsync(string s)
    {
      var result = await ReverseImplAsync(s);
      // Check our "postcondition"
      Contract.Assume(result != null);
      return result;
    }
    private static async Task<string> ReverseImplAsync(string s)
    {
      return ...;
    }
