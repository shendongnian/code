    string[] spliiter = raw.Split(new char[] { ' ', '\n' });
    List<string> splitterList = spliiter.ToList<string>(), xml = new List<string>();
    splitterList.RemoveAll(x => x == "");
    string temp;
    for (int i = 0; i < splitterList.Count() - 1; i++)
    {
        temp = "";
        if (StringExtensions.ContainsAll(splitterList[i], new string[] { "<", ">" }))
        {
            temp = splitterList[i];
            xml.Add(temp);
        }
        else if (!splitterList[i].EndsWith("\r"))
        {
            if (StringExtensions.ContainsNone(splitterList[i], new string[] { "<", ">" }))
            {
                if (splitterList[i + 1].EndsWith("\r") || splitterList[i + 1].EndsWith("\r\n"))
                {
                     temp = splitterList[i] + " " + splitterList[i + 1];
                     xml.Add(temp);
                     i++;
                 }
            }
        }
        else if (splitterList[i].EndsWith("\r") && StringExtensions.ContainsNone(splitterList[i], new string[] { "<", ">" }))
        {
            if (splitterList[i + 1].EndsWith("\r") && StringExtensions.ContainsNone(splitterList[i + 1], new string[] { "<", ">" }))
            {
                temp = splitterList[i];
                do
                {
                    temp = temp + " " + splitterList[i + 1];
                    i++;
                 } while (splitterList[i + 1].EndsWith("\r") && StringExtensions.ContainsNone(splitterList[i + 1], new string[] { "<", ">" }) || StringExtensions.ContainsNone(splitterList[i + 1], new string[] { "<", ">", "\r", "\n" }));
                 temp.Replace('\n', ' ');
                 xml.Add(temp);
             }
             else
             {
                 temp = splitterList[i];
                 xml.Add(temp);
             }
         }
     }
     xml = (xml.Select(s => (s.Replace('\r', ' ').Trim()))).ToList();
     string final_xml = string.Join("\n", xml.ToArray());
