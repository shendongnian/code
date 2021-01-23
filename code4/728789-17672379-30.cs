    public interface IUiWindow
    {
        void Show();
        void Hide();
    }
    
    public interface IMainWindow : IUiWindow
    {
        event EventHandler Calibrate;
    }
    
    public interface ICalibrationWindow : IUiWindow
    {
        event EventHandler SomethingMustBeDone;
    }
