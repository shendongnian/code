    void Main()
    {
        // Define some actions to test and add them to a collection
        var ActionPaths = new List<ActionPath>() {
            new ActionPath() {TestPath = "/foo/*/baz",   Action = "include"},
            new ActionPath() {TestPath = "/foo/bar/*",   Action = "exclude"},
            new ActionPath() {TestPath = "/foo/doo/boo", Action = "exclude"},
        };
        // Sort the list of actions based on the depth of the wildcard
        ActionPaths.Sort();
        // the path for which we are trying to find the corresponding action
        string PathToTest = "/foo/bar/baz";
         
        // Test all ActionPaths from the top down until we find something
        var found = default(ActionPath);
        foreach (var ap in ActionPaths) {
            if (ap.IsMatching(PathToTest)) {
                found = ap;
                break;
            }
        }
        // At this point, we have either found an Action, or nothing at all
        if (found != default(ActionTest)) {
            // Found an Action!
        } else {
            // Found nothing at all :-(
        }
    }
    // Hold and Action Test
    class ActionPath : IComparable<ActionPath>
    {
        public string TestPath;
        public string Action;
        // Returns true if the given path matches the TestPath
        public bool IsMatching(string path) {
            var t = TestPath.Replace("*",".*?");
            return Regex.IsMatch(path, "^" + t + "$");
        }
        
        // Implements IComparable<T>
        public int CompareTo(ActionPath other) {
           if (other.TestPath == null) return 1;
           var ia = TestPath.IndexOf("*");
           var ib = other.TestPath.IndexOf("*");
           if (ia < ib) return 1;       
           if (ia > ib) return -1;
           return 0;
       }
    }
