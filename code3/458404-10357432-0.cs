    public interface IStatus { public int Status { get; set; } }
    public class Child : IStatus { }
    public class Parent : IStatus
    {public Child Child { get; set; }  }
    Func<IStatus, bool> filter = (x) => x.Status == 1;
    var list = Parents.Where(parent => filter(parent) && filter(parent.Child));
