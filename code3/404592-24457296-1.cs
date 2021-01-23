    public static Result<Thing> ParseThing(string line)
    {
         try 
         {
              // Parse a Thing (or return a parsing error.)
              return new Result<Thing> { Data = thing, Success = true };
         }
         catch (Exception ex)
         {
              return new Result<Thing> { Data = null, Success = false, ErrorMessage = "..." };
         }
    }
    ...
    var results = lines.Select(ParseThing);
    foreach (var result in results)
    {
        // Check result.Success and deal with successes/failures here.
    }
