    string s1 = "abcd"; // is neither null nor empty.
    string s2 = "";     // is null or empty
    string s3 = null;   // is null or empty
    string.IsNullOrWhiteSpace(s1); // returns false
    string.IsNullOrWhiteSpace(s2); // returns true
    string.IsNullOrWhiteSpace(s3); // returns true
