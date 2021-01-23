    public interface ISomeInterface
    {
         IEnumerable<SaveStep> SaveData();
    }
    public class SomeClass : SomeBaseClass, ISomeInterface
    {
        public virtual IEnumerable<SaveStep> SaveData()
        {
            foreach(var item in base.SaveData())
               yield return item;
            yield return new SaveStep { ... }
        }
    }
