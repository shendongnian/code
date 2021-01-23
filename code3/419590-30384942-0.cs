    public interface IMyService
    {
        void DoStuff();
    }
    public class MyService : IMyService
    {
        private Data mData;
        public MyService(Data data)
        {
            mData = data;
        }
        public void DoStuff()
        {
            Console.WriteLine("{0} @ {1}", mData.DependencyValue, mData.ConstructedAt);
        }
        public Data GetData() { return mData; }
    }
