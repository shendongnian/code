    public enum ChosenType {
        [Repo(typeof(RepA))] A = 0,
        [Repo(typeof(RepB))] B = 1
    }
    public class RepoAttribute : Attribute {
        public RepoAttribute(Type repoType) { RepoType = repoType; }
        public Type RepoType { get; set; }
    }
    class Program
    {
        static void Main()
        {
            ChosenType chosentype = RandomChosenType(); //A or B
            // Make an instance of the appropriate repo based on the mapping
            // to the enum value.
            // This is a moderately expensive call, and there's room for improvement
            // by using expression trees and caching lambda expressions.
            var repo = (IRepo)Activator.CreateInstance(
                ((RepoAttribute)typeof(ChosenType).GetMember(chosentype.ToString())
                    .Single().GetCustomAttributes(typeof(RepoAttribute), false).Single()
                ).RepoType);
            var list = repo.GetAll();
            repo.SaveAll(list);
            Console.Read();
        }
        static Random _rand = new Random();
        static ChosenType RandomChosenType()
        {
            return (ChosenType)_rand.Next(0, 2);
        }
    }
    public class A { /* No change */ }
    public class B { /* No change */ }
    public interface IRepo {
        List<object> GetAll();
        void SaveAll(List<object> list);
    }
    public abstract class Repo<T> : IRepo {
        List<object> IRepo.GetAll() {
            return GetAll().Cast<object>().ToList();
        }
        void IRepo.SaveAll(List<object> list) {
            SaveAll(list.Cast<T>().ToList());
        }
        public abstract List<T> GetAll();
        public abstract void SaveAll(List<T> list);
    }
    public class RepA : Repo<A> {
        public override List<A> GetAll() { /* No change except the signature */ }
        public override void SaveAll(List<A> list) { /* No change except the signature */ }
    }
    public class RepB : Repo<B> {
        public override List<B> GetAll() { /* No change except the signature */ }
        public override void SaveAll(List<B> list) { /* No change except the signature */ }
    }
