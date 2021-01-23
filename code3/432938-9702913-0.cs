    string sentence = "-random text- $0.15 USD";
    string[] doubleArray = System.Text.RegularExpressions.Regex.Split(sentence, @"[^0-9\.]+")
                           .Where(c => c != "." && c.Trim() != "").ToArray();
    if (doubleArray.Count() > 0)
    {
         double value = double.Parse(doubleArray[0]);
    }
    output:
    .15
