        string macAddr = "AAEEBBCCDDFF";
        var splitMac = SplitStringInChunks(macAddr);
        static string SplitStringInChunks(string str)
        {
            for (int i = 2; i < str.Length; i += 3)
                 str =  str.Insert(i, ":");
            return str;
        }
