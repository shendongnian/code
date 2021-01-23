    void ProcessResult(Just<string> val) {
        Console.WriteLine(val);
    }
    void ProcessResult(Nothing<string> n) {
        Console.WriteLine("Key not found");
    }
    var dict = new MyDictionary<string, string>();
    ...
    dynamic x = dict["key"];
    ProcessResult(x);
