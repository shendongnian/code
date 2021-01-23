    public class MyTaskController
    {
        private MainForm _main;
        private TempCalib _tempCalib;
    
        public void Start()
        {
            _main = new MainForm();
            _main.Calibrate += OnCalibrationRequested;
            _main.Show(); // Or whatever else
        }
    
        private void OnCalibrationRequested(object sender, EventArgs e)
        {
            if (_tempCalib == null)
            {
                _tempCalib = new TempCalib();
                _tempCalib.SomethingMustBeDone += OnSomethingMustBeDone();
            }
    
            _tempCalib.Show();
        }
    
        private OnSomethingMustBeDone(object sender, EventArgs e)
        {
            // Perform the task here then hide calibration window
            _tempCalib.Hide();
        }    
    }
