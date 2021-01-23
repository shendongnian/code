    class ApplicationMenu
    {
        // The "File" menu
        IMenuItem File { get; }
    }
    interface IMenuRegistrar
    {
        void Register(ApplicationMenu menu);
    }
