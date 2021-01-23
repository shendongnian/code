    string s;
    if (someCondition) { s = someValue; }
    else if (someOtherCondition) { s = someOtherValue; }
    else { throw new Exception("Please initialize s."); }
    Console.WriteLine(s)
