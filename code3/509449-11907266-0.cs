    //ConcreteWindow class must not be visible to the final user.
    class ConcreteWindow : public AbstractWindow
    {
        ...
    };
    class GUIManager
    {
    public:
        AbstractWindow* createWindow()
        {
            return new ConcreteWindow();
        }
        ...
    };
