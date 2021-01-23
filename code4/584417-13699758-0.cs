    public class Dice
    {
        private Random _Random;
        private BackgroundWorker _Worker;
        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class.
        /// </summary>
        public Dice()
        {
            _Random = new Random();
            InitializeDefaultValues();
            InitializeBackgroundWorker();
        }
        /// <summary>
        /// Occurs when the dice finished rolling.
        /// </summary>
        public event EventHandler Rolled;
        /// <summary>
        /// Occurs while the dice is rolling and the value has changed.
        /// </summary>
        public event EventHandler RollingChanged;
        /// <summary>
        /// Gets or sets the including maximum value that the dice can return.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        [DefaultValue(6)]
        public int Maximum { get; set; }
        /// <summary>
        /// Gets or sets the including minimum value that the dice can return.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        [DefaultValue(1)]
        public int Minimum { get; set; }
        /// <summary>
        /// Gets the result that this dice currently has.
        /// </summary>
        public int Result { get; private set; }
        /// <summary>
        /// Gets or sets the duration of the rolling.
        /// </summary>
        /// <value>
        /// The duration of the rolling.
        /// </value>
        [DefaultValue(typeof(TimeSpan), "00:00:03")]
        public TimeSpan RollingDuration { get; set; }
        /// <summary>
        /// Starts rolling the dice.
        /// </summary>
        public void Roll()
        {
            if (!_Worker.IsBusy)
            {
                CheckParameters();
                _Worker.RunWorkerAsync();
            }
        }
        private void CheckParameters()
        {
            if (Minimum >= Maximum)
            {
                throw new InvalidOperationException("Minimum value must be less than the Maximum value.");
            }
            if (RollingDuration <= TimeSpan.Zero)
            {
                throw new InvalidOperationException("The RollingDuration must be greater zero.");
            }
        }
        private void InitializeBackgroundWorker()
        {
            _Worker = new BackgroundWorker();
            _Worker.WorkerReportsProgress = true;
            _Worker.DoWork += OnWorkerDoWork;
            _Worker.ProgressChanged += OnWorkerProgressChanged;
            _Worker.RunWorkerCompleted += OnWorkerRunWorkerCompleted;
        }
        private void InitializeDefaultValues()
        {
            Minimum = 1;
            Maximum = 6;
            Result = Minimum;
            RollingDuration = TimeSpan.FromSeconds(3);
        }
        private void OnWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var finishTime = DateTime.UtcNow + RollingDuration;
            while (finishTime > DateTime.UtcNow)
            {
                Result = _Random.Next(Minimum, Maximum + 1);
                _Worker.ReportProgress(0);
                // ToDo: Improve sleep times for more realistic rolling.
                Thread.Sleep(50);
            }
        }
        private void OnWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RaiseEvent(RollingChanged);
        }
        private void OnWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RaiseEvent(Rolled);
        }
        private void RaiseEvent(EventHandler handler)
        {
            var temp = handler;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }
    }
