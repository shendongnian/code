    interface IChildControl
    {
        ParentControl Parent { get; set; }
    }
    public abstract class Control : IChildControl //such as a button or radio button
    {
        ParentControl IChildControl.Parent { get; set; }
    }
