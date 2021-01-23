    public class MyEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    public static class MyEntityListExtension
    {
        public static List<MyEntity> AddList(this List<MyEntity> FirstList, List<MyEntity> SecondList)
        {
            List<MyEntity> ReturnList = new List<MyEntity>();
            foreach (MyEntity CurrentEntity in FirstList)
            {
                MyEntity TempEntity = SecondList.Where<MyEntity>(x => x.Name.Equals(CurrentEntity.Name)).SingleOrDefault<MyEntity>();
                if (TempEntity != null)
                {
                    ReturnList.Add(new MyEntity()
                    {
                        Name = CurrentEntity.Name,
                        Value = CurrentEntity.Value + TempEntity.Value
                    });
                }
            }
            return ReturnList;
        }
    }
