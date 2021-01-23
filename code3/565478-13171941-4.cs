    public static string TrimEnd(this string s, string trimmer)
    {
        //reverse the original string we are trimmimng
        string reversed = string.Concat(s.Reverse());
        //1. reverse the trimmer (string we are searching for)
        //2. in the Where clause choose only characters which are not equal in two strings on the i position
        //3. if any such character found, we decide that the original string doesn't contain the trimmer in the end
        if (trimmer.Reverse().Where((c, i) => reversed[i] != c).Any())
            return s; //so, we return the original string
        else //otherwise we return the substring
            return s.Substring(0, s.Length - trimmer.Length);
    }
