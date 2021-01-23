    var dic = new Dictionary<string, string>();
    dic.Add("910235487", "Diabetes, tumors, sugar sick");
    dic.Add("120391052", "Fever, diabetes");
    char[] delimiters = new char[] { ' ', ',' };
    var wordCodes =
        from kvp in dic
        from word in kvp.Value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        let code = long.Parse(kvp.Key)
        select new { Word = word, Code = code };
    var fullTextIndex =
        wordCodes.ToLookup(wc => wc.Word, wc => wc.Code, StringComparer.OrdinalIgnoreCase);
    long[] test1 = fullTextIndex["sugar"].ToArray();       // Gives 910235487
    long[] test2 = fullTextIndex["diabetes"].ToArray();    // Gives 910235487, 120391052
