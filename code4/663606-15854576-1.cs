    class Character
    {
        public string Name { get; set; }
    }
    
    var c = new Character();
    var c2 = c;
    var arr1 = new Character[] { c };
    var arr2 = new Character[] { c };
    
    arr1[0].Name = "Foo";
    Console.WriteLine(arr2[0].Name); // "Foo"
    Console.WriteLine(c2.Name); // also "Foo"
