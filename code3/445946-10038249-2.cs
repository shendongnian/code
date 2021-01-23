    class Program
        {
            static void Main(string[] args)
            {
                List<TypeA> typeAList = new List<TypeA>();
                typeAList.Add(new TypeA() { ID = Guid.NewGuid() });
                typeAList.Add(new TypeA() { ID = Guid.NewGuid() });
                typeAList.Add(new TypeA() { ID = Guid.NewGuid() });
    
                List<TypeB> typeBList = new List<TypeB>();
                typeBList.Add(new TypeB() { ID = typeAList[0].ID });
                typeBList.Add(new TypeB() { ID = typeAList[1].ID });
    
                //this is the statement
               var keep = typeAList.Where(a => typeBList.FirstOrDefault(b => a.ID == b.ID) == null);
            }
        }
    
        class TypeA
        {
            public Guid ID { get; set; }
        }
    
        class TypeB
        {
            public Guid ID { get; set; }
        }
