    // using System.Globalization;
    TextElementEnumerator e = StringInfo.GetTextElementEnumerator("Les Misאֳrables");
    List<string> elements = new List<string>();
    while (e.MoveNext())
    {
        elements.Add(e.GetTextElement());
    }
    elements.Reverse();
    string n = string.Concat(elements);  // selbarאֳsiM seL
