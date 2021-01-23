    using System;
    public class SplitTest {
    public static void Main() {
        string teststring = "test1;#test2;#test3;#";
        string [] split = teststring.Split(new Char []{';','#'},StringSplitOptions.RemoveEmptyEntries);
        
        var SplitStringList = new Dictionary<String, String>();
        for (int i=0;i<split.Length;i++)
        {
            if (split[i].Trim() != "")
            {
                SplitStringList.Add("string"+1, split[i]);
            }
        
        }
      }
    }
