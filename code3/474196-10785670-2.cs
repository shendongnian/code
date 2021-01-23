    // Foo's are looked up by integer
    public class FooEntryFinder : IEntryFinder<int>
    {
      public Entry findEntry(int processId)
      {
         // Implementation
      }
    }
    // Baa's are looked up by string
    public class BaaEntryFinder : IEntryFinder<string>
    {
      public Entry findEntry(string processId)
      {
         // Implementation
      }
    }
