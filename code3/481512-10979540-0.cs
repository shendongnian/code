    public class TestEntity
    {
        public int Number { get; set; }
        public TestEntity(int num)
        {
            Number = num;
        }
    }
    
    public void WriteResult()
    {
        List<TestEntity> lstA = new List<TestEntity>();
        List<TestEntity> lstB = new List<TestEntity>();
        for (int i = 0; i < 10; i++)
        {
             lstA.Add(new TestEntity(i));
             lstB.Add(new TestEntity(i+4));
        }
    
        List<TestEntity> result = lstA.FindAll(teA => !lstB.Any(teB => teA.Number == teB.Number)); //This will give you all entities in lstA that does not have any equals in lstB
        foreach (var item in result)
        {
             Console.WriteLine(item.Number);
        }
    }
