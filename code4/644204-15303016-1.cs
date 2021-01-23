    [Test]
    [TestCase("parralele", "parallel", "par[ralele]")]
    [TestCase("personil", "personal", "person[i]l")]
    [TestCase("disfuncshunal", "dysfunctional", "d[isfuncshu]nal")]
    [TestCase("ato", "auto", "a[]to")]
    [TestCase("inactioned", "inaction", "inaction[ed]")]
    [TestCase("refraction", "fraction", "[re]fraction")]
    public void CompareStringsTest(string attempted, string correct, string expectedResult)
    {
        int first = -1, last = -1;
    
        string result = null;
        int shorterLength = (attempted.Length < correct.Length ? attempted.Length : correct.Length);
    
        // First - [
        for (int i = 0; i < shorterLength; i++)
        {
            if (correct[i] != attempted[i])
            {
                first = i;
                break;
            }
        }
    
        // Last - ]
        var a = correct.Reverse().ToArray();
        var b = attempted.Reverse().ToArray();
        for (int i = 0; i < shorterLength; i++)
        {
            if (a[i] != b[i])
            {
                last = i;
                break;
            }
        }
    
        if (first == -1 && last == -1)
            result = attempted;
        else
        {
            var sb = new StringBuilder();
            if (first == -1)
                first = shorterLength;
            if (last == -1)
                last = shorterLength;
            if (first > 0)
                sb.Append(attempted.Substring(0, first));
    
            sb.Append("[");
    
            if (last > -1 && last + first < attempted.Length)
                sb.Append(attempted.Substring(first, attempted.Length - last - first));
    
            sb.Append("]");
    
            if (last > 0)
                sb.Append(attempted.Substring(attempted.Length - last, last));
    
            result = sb.ToString();
        }
        Assert.AreEqual(expectedResult, result);
    }
