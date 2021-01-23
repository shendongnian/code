    class ClassA
    {
        public int A_Id { get; set; }
        public IEnumerable<int> B_Ids { get; set; }
    }
        
    var newAs = (from a in As from bId in a.B_Ids select new ClassA() {A_Id = a.A_Id, B_Ids = new int[] {bId}});
        
