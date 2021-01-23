    var s = "A+SUM(A)+B-C";
    var replaceBeginningA = s.Replace("A+", "0+");
    var replaceSumA = s.Replace("SUM(A)", "0");
    Console.WriteLine(replaceBeginningA); // 0+SUM(A)+B-C
    Console.WriteLine(replaceSumA); // A+0+B-C
