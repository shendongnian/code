    string[] subjects = new string[] { "maths", "english", "maths", "hindi", "english" };
    Dictionary<string, int> subjectCounts = new Dictionary<string, int> ();
    foreach (string subject in subjects) {
        if (subjectCounts.ContainsKey(subject))
            subjectCounts[subject]++;
        else
            subjectCounts.Add(subject, 1);
    }
    List<string> output = new List<string>();
    foreach (KeyValuePair<string, int> pair in subjectCounts) {
        if (pair.Value > 1) {
            for (int i = 1; i <= pair.Value; i++)
                output.Add(i + "_" + pair.Key);
        } else {
            output.Add(pair.Key);
        }
    }
    foreach (string subject in output)
        Console.WriteLine(subject);
