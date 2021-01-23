    public class MyEntityEqualityComparer : EqualityComparer<MyEntity>
    {
       public override bool Equals(MyEntity x, MyEntity y)
       {
          return x.Id == y.Id;
       }
       public override int GetHashCode(MyEntity obj)
       {
          return obj.Id;
       }
    }
    context.MyEntities.Local.Contains(myEntity, new MyEntityEqualityComparer());
