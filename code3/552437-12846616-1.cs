    class Thing {
        public string Prop1 {get; set; }
        public string Prop2 {get; set; }
        public string Prop3 {get; set; }
        public int Prop4 {get; set; }
    }
    List<Thing> list = new List<Thing>();
   
    list.Add(new Thing() { Prop1 = "expensive", Prop2 = "costly", Prop3 = "pricy", Prop4 = 0};
   
