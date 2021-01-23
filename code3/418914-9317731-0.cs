    public class Person
    {
      [RelativeDateTimeValidator(-120, DateTimeUnit.Year, -18, DateTimeUnit.Year,
               Ruleset="RuleSetA", MessageTemplate="Must be 18 years or older.")]
      public DateTime DateOfBirth
      {
        get
        {
          return dateOfBirth;
        }
      }
    }
