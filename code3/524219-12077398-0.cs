    List<string> list = new List<string>() { 
                        "0-5.jpeg",
                        "0-9.jpeg",
                        "0-0.jpeg",
                        "0-1.jpeg",
                        "0-10.jpeg",
                        "0-12.jpeg"};
    list.CustomSort().ToList().ForEach(x => Console.WriteLine(x));
