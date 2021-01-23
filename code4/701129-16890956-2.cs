    class TimerParam
    {
        public decimal ActualSpeed { get; set; }
        public decimal SpeedRequest { get; set; }
        public Decimal PwmAuto { get; set; }
        public decimal PreValReg { get; set; }
    }
    class Motor
    {
        public static System.Timers.Timer _timer;
        int valReg = 30;
        public TimerParam Param { get; set; }
        public void PID(TimerParam param)
        {
            Param = param;
            _timer = new System.Timers.Timer();
            _timer.Interval = (3000);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timerAutoset);
            _timer.Enabled = true;
            // {....}
            Param.PwmAuto = valReg;
            Param.PreValReg = valReg - 1;
        }
        static void _timerAutoset(object sender, System.Timers.ElapsedEventArgs e)
        {
            /* here you can use:
             Param.ActualSpeed
             Param.SpeedRequest
             Param.PwmAuto
             Param.PreValReg
            */
        }
    }
