    public interface IMyInterface
    {
        List<IMyInterface> GetAll(string whatever);
    }
    public class Program : IMyInterface
    {
        public string Member { get; set; }
        public List<IMyInterface> GetAll(string whatever)
        {
            return new List<Program>()
                { new Program() { Member = whatever } }
                .ConvertAll<IMyInterface>(x => x);
        }
        static void Main(string[] args)
        {
            List<IMyInterface> all = new Program().GetAll("whatever");
            Console.WriteLine(all.Count);
        }
    }
