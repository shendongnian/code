    IEnumerable<String> otherElements = new[] {"abc", "def", "ghi" };
    IEnumerable<ObjectA> myObjects = GetObjects();
    var matchesFound = otherElements.Join( // Take the first collection.
                  myObjects, // Take the second collection.
                  s => s, // Use the elements in the first collection as key (the string).
                  obj => obj.ToEquatableString(),  // Create a string from each object for comparison.
                  (s, obj) => obj, // From the matching pairs take simply the objects found.
                  StringComparer.OrdinalIgnoreCase); // Use a special string comparer if desired.
