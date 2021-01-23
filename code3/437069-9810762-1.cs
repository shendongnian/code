    string yourstring = "{@</w:t></w:r><w:r><w:t>Obrigado</w:t></w:r><w:r><w:t>}{@......}...";
    Regex reg1 = new Regex(@"{.*?@.*?}");
    Regex reg2 = new Regex(@"<.*?>");
    MatchCollection matches = reg1.Matches(yourstring);
    List<string> names = new List<string>();
    foreach (Match match in matches)
    {
        // yeah.. this could be cleaned up. 
        names.Add((string)reg2.Replace(match.ToString(), ""));
    }
    for (int i = 0; i < names.Count; i++)
    {
        yourstring = yourstring.Replace(matches[i].ToString(), names[i]);
    }
