    public interface ISharedObject
    {
       string Reference { get; set; }
       string Name { get; set; }
       string ImageURL { get; set; }
       bool IsVisible { get; set; }
       bool IsAdminVisible { get; set; }
       string FrontEndDetailsURL { get; set; }
       string AdminDetailsURL { get; set; }
       object OriginalObject { get; set; }
       string ObjectDescription { get; set; }
    }
    
    public partial class Event : ISharedObject
    {}
