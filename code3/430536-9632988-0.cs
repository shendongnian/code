    public interface IView
    {
        String Result { get; set; }
        void AddButtonClickHandler(Action handler);
    }
