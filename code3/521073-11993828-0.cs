    List<string> strArr = new List<string>();
    strArr.Add("firstItem");
    strArr.Add("secondItem");
    strArr.Add("thirdItem");
    IEnumerable<IEnumerable<string>> summary = permutations<string>(strArr);
