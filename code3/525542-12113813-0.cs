    class Test {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
    var list = new List<Test> {
        new Test {A = "quick", B = "brown", C = "fox"}
    ,   new Test {A = "jumps", B = "over", C = "the"}
    ,   new Test {A = "lazy", B = "dog", C = "quick"}
    ,   new Test {A = "brown", B = "fox", C = "jumps"}
    ,   new Test {A = "over", B = "the", C = "lazy"}
    ,   new Test {A = "dog", B = "quick", C = "brown"}
    ,   new Test {A = "fox", B = "jumps", C = "over"}
    ,   new Test {A = "the", B = "lazy", C = "dog"}
    ,   new Test {A = "fox", B = "brown", C = "quick"}
    ,   new Test {A = "the", B = "over", C = "jumps"}
    ,   new Test {A = "quick", B = "dog", C = "lazy"}
    ,   new Test {A = "jums", B = "fox", C = "brown"}
    ,   new Test {A = "lazy", B = "the", C = "over"}
    ,   new Test {A = "brown", B = "quick", C = "dog"}
    ,   new Test {A = "over", B = "jumps", C = "fox"}
    ,   new Test {A = "dog", B = "lazy", C = "the"}
    };
    var byA = list.ToLookup(v => v.A);
    var byB = list.ToLookup(v => v.B);
    var byC = list.ToLookup(v => v.C);
    var all = byA["quick"].Intersect(byB["dog"]);
    foreach (var test in all) {
        Console.WriteLine("{0} {1} {2}", test.A, test.B, test.C);
    }
    all = byA["fox"].Intersect(byC["over"]);
    foreach (var test in all) {
        Console.WriteLine("{0} {1} {2}", test.A, test.B, test.C);
    }
