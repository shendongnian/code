    class Dto
    {
        public int Pro1 { get; set; }
        public int Pro2 { get; set; }
        public int Pro3 { get; set; }
    }
    var result = ExampleList.Select(x => new Dto { 
                                           Pro1 = x.attr1,
                                           Pro2 = x.attr2,
                                           Pro3 = x.attr3 
                                        });
