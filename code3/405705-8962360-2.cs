    //Interface
    public interface IControl : IComponent
    {
        void DoSomething();
        // To be inherited from UserControl.
        Size Size { get; set; }
        bool Focus();
        event EventHandler FontChanged;
    }
