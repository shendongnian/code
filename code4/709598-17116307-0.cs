    foreach (var s in genSum(500).Take(5))
    {
        Console.WriteLine(s);
    }
---
    public static IEnumerable<string> genSum(int askedNumber)
    {
        Random r = new Random();
        while (true)
        {
            var i = r.Next(0, askedNumber);
            yield return i + "+" + (askedNumber - i);
        }
    }
