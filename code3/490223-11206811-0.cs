    public class ViewModelOne : IReusableView
    {
        public string Name { get; set; }
        public string Something { get; set; }
        public int ANumber { get; set; }
    }
    public class ViewModelTwo : IReusableView
    {
        public string Name { get; set; }
        public string Thing { get; set; }
        public string SomethingElse { get; set; }
        public int ANumber2 { get; set; }
    }
    public interface IReusableView
    {
        string Name { get; }
    }
