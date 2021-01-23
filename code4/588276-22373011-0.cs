        string macAddr = "AAEEBBCCDDFF";
        var split = SplitStringInChunks(macAddr);
        var res = string.Join(":", split);
        }
        static IEnumerable<string> SplitStringInChunks(string str)
        {
            for (int i = 0; i < str.Length; i += 2)
                yield return str.Substring(i, 2);
        }
