    Student st1 = new Student
        {
            Name = "John",
            RollNo = "Roll 1"
        };
    Subject sb1 = new Subject
        {
            Code = "Subject 1"
        };
    Subject sb2 = new Subject
        {
            Code = "Subject 2"
        };
    Subject sb3 = new Subject
        {
            Code = "Subject 3"
        };
    // Create the associative dictionary for subjects.
    var subjectsByCode = new [] { sb1, sb2, sb3 }.ToDictionary(subject => subject.Code, subject => subject);
    // Many-to-many relationship: Student (RollNo) <=> Subject (Code).
    List<KeyValuePair<string,string>> roleList = new List<KeyValuePair<string,string>>
        {
            new KeyValuePair<string, string>(st1.RollNo, sb1.Code),
            new KeyValuePair<string, string>(st1.RollNo, sb2.Code),
            new KeyValuePair<string, string>(st1.RollNo, sb3.Code)
        };
    // Create Student RollNo => List of Subjects dictionary.
    Dictionary<string, List<Subject>> studentRollNoToSubjects = roleList
        .GroupBy(pair => pair.Key) // Group by RollNo
        .ToDictionary(group => group.Key, // Key of the dictionary is RollNo.
            group => group.Select(pair => subjectsByCode[pair.Value]).ToList()); // List of subjects is created using subjects-by-code dictionary.
