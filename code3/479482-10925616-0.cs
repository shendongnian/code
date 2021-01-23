    public interface IClass1
    {
        IList<IList<int>> ListList { get; set; }
        void AddList(List<int> nList);
    }
    public class Class1 : IClass1
    {
        public IList<IList<int>> ListList { get; set; }
        public void AddList(List<int> nList)
        {
            ListList.Add(nList);
        }
    }
