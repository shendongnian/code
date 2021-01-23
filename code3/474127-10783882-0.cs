    WebClient c = new WebClient();
    String members = c.DownloadString("http://www.powerbot.org/community/members/");
    int times = Regex.Matches(members, "<h3 class='ipsType_subtitle'>").Count;
    Console.WriteLine(times.ToString());
    
    var member = string.Empty;//extracted value
    for (int i = 1; i < times; i++)
    {
        try
        {
            int start = members.IndexOf("<h3 class='ipsType_subtitle'>");
            member = members.Substring(start, 500);
            members = members.Remove(start, 500);
            String[] next = member.ToString().Split(new string[] { "a href='" }, StringSplitOptions.None);
            String[] link = next[1].Split(' ');
            Console.WriteLine(link[0].Replace("'", ""));
        }
        catch(Exception e) { Console.WriteLine("Failed: " + e.ToString()); }
    }
    Console.Read();
