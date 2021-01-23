    public static class MyEntityListExtension
    {
        public static List<MyEntity> AddList(this List<MyEntity> FirstList, List<MyEntity> SecondList)
        {
            return FirstList.Join<MyEntity, MyEntity, string, MyEntity>(SecondList, x => x.Name, y => y.Name, (x, y) =>
                {
                    return new MyEntity()
                    {
                        Name = x.Name,
                        Value = x.Value + y.Value
                    };
                }).ToList<MyEntity>();
        }
    }
