                string sought = "Version:";
                foreach (string tmp in lines)
                {
                    if (tmp.Contains(sought))
                    {
                        int position = tmp.IndexOf(sought) + sought.Length;
                        string version = tmp.Substring(tmp.IndexOf(sought) + sought.Length);
                        string[] versionParts = version.Split('.');
                        VersionCompare(versionParts, new string[]{"2", "0", "0"});
                    }
                }
    /// <summary>Returns 0 if the two versions are equal, else a negative number if the first is smaller, or a positive value if the first is larder and the second is smaller.</summary>
    private int VersionCompare(string[] left, string[] right)
    {
        for(int i = 0; i < Math.Min(left.Length, right.Length); ++i)
        {
            int leftValue = int.Parse(left[i]), rightValue = int.Parse(right[i]);
            if(leftValue != rightValue) return leftValue - rightValue;
        }
        return left.Length - right.Length;
    }
