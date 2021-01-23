    public interface IContravariant<T, in TKey> where T : class
    {
        T FindSingle(TKey id);
    }
    public class objCV : IContravariant<Project, object>
    {
        public Cliente FindSingle(object id)
        {
            return null;
        }
        public static void test()
        {
            objCV objcv = new objCV();
            IContravariant<Project, Project> projcv;
            IContravariant<Project, int> intcv;
            projcv = objcv;
            intcv = objcv;
        }
    }
