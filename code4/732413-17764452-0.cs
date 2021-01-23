    public interface IJob
    {
        MyJobType Type{ get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        void RunJob();
    }
