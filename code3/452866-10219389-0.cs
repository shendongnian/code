    counter = 0;
    while (m.Success)
    {
            if( counter % 4 == 0 )
            {
                testMatch = "";
                //
                testMatch += System.Text.RegularExpressions.Regex.Unescape(m.Groups[0].ToString()).Trim();
                top.Add(new Top(testMatch));
                m = m.NextMatch();
            }
            counter++;
    }
