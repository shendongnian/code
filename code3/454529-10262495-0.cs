    // Base class
    class Button
    {
        protected Button()
        {
        }
        public string Name { get; set; }
    }
    // Factory interface
    public interface ButtonFactory
    {
        Button CreateButton();
    }
    // And the concrete classes
    class WindowsButton : Button
    {
        // ...
    }
    class WindowsButtonFactory : ButtonFactory
    {
        public Button CreateButton()
        {
            return new WindowsButton();
        }
    }
    class MacButton : Button
    {
        // ...
    }
    class MacButtonFactory : ButtonFactory
    {
        public Button CreateButton()
        {
            return new MacButton();
        }
    }
