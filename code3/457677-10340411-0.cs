    public MyClass {
     readonly IEnumerable<Rule> _rules;
     public MyClass(IEnumerable<Rule> rules) {
        _rules
     }
     public bool CompareSysInfo(SystemInfo expected, SystemInfo comp) {
       // i prefer linq over loops
       var result = from r in _rules
                    where !r.CheckRule(expected, comp)
                    select false;
       return result.Count() > 0; // only returns true if no rule checks return false
     }
    }
