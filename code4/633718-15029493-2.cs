    // using System.Globalization;
    TextElementEnumerator enumerator =
        StringInfo.GetTextElementEnumerator("Les Misאֳrables");
    List<string> elements = new List<string>();
    while (enumerator.MoveNext())
        elements.Add(enumerator.GetTextElement());
    elements.Reverse();
    string reversed = string.Concat(elements);  // selbarאֳsiM seL
