    string s1 = "SomeTextHereThatIsTheSource";
    string s2 = "SomeTextHereThat";
    string s3 = "SomeTextHereThatIsCloseToTheSourceButNotTheSame";
    Console.WriteLine(MatchFromStart(s1, s2));   // SomeTextHereThat
    Console.WriteLine(MatchFromStart(s2, s1));   // SomeTextHereThat
    Console.WriteLine(MatchFromStart(s3, s1));   // SomeTextHereThatIs
    Console.WriteLine(MatchFromStart("", s1));   // (blank string)
    Console.WriteLine(MatchFromStart(s3, ""));   // (blank string)
    Console.WriteLine(MatchFromStart(null, s1)); // (blank string)
    Console.WriteLine(MatchFromStart(s2, null)); // (blank string)  
