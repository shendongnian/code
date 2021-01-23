    var verboseResult = 
        (s1.Do(Console.WriteLine).Plus(s2.Do(Console.WriteLine)))
        .Over(s3.Do(Console.WriteLine))
        .Plus(s4.Do(Console.WriteLine))
        .Times(2.0.Const())
        .Do(x => Console.WriteLine("(s1 + s2) / s3 + s4 * 2 = " + x));
