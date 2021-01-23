    public interface IDataBag
    {
        string UserControl { get; set; }
        string LoadMethod { get; set; }
        dynamic Params { get; set; }
        int Height { get; set; }
    }
