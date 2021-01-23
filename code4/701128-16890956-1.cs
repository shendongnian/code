    class Motor
    {
        public static System.Timers.Timer _timer;
        int valReg = 30;
        public delegate TimerParam ParameterizedTimerDelegate();
        public static ParameterizedTimerDelegate TimerCallback { get; set; }
        public void PID()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = (3000);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timerAutoset);
            _timer.Enabled = true;
            // {....}
            //Param.PwmAuto = valReg;
            //Param.PreValReg = valReg - 1;
        }
        static void _timerAutoset(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimerParam param = TimerCallback();
            /* here you can use:
             Param.ActualSpeed
             Param.SpeedRequest
             Param.PwmAuto
             Param.PreValReg
            */
        }
    }
