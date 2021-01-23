    public abstract class MiscellaneousDataBase
    {
        public abstract string Key { get; set; }
    }
    public class MiscellaneousData : MiscellaneousDataBase
    {
        public override string Key { get; set; }
        public int X { get; set; }
    }
