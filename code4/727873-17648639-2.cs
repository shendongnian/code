    public static class Mapper
    {
        public static T1 ToT1(T2 t)
        {
            return new T1 { ID = t.ID, Name = t.Name };
        }
        public static T2 ToT2(T1 t)
        {
            return new T2 { ID = t.ID, Name = t.Name };
        }
    }
    List<T1> listOfT1 = listOfT2.Select(Mapper.ToT1).ToList();
    List<T2> listOfT2 = listOfT1.Select(Mapper.ToT2).ToList();
