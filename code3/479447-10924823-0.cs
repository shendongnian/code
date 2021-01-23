    public partial class ProgressBarEx : ProgressBar
    {
        private readonly Dictionary<Guid, double> _partsProgress =
            new Dictionary<Guid, double>();
        private readonly Dictionary<Guid, double> _partsSizes =
            new Dictionary<Guid, double>();
        private double _value;
        private double _maximum;
        public ProgressBarEx()
        {
            this.InitializeComponent();
        }
        public int Parts
        {
            get { return this._partsSizes.Count; }
        }
        public new int Minimum { get; private set; }
        public new double Maximum
        {
            get { return this._maximum; }
            private set
            {
                this._maximum = value;
                base.Maximum = (int)value;
            }
        }
        public new double Value
        {
            get { return this._value; }
            private set
            {
                this._value = value;
                base.Value = (int)value;
            }
        }
        [Obsolete("Not useable in ProgressBarEx.")]
        public new int Step
        {
            get { return 0; }
        }
        public Guid AddPart(double size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size");
            }
            var partId = Guid.NewGuid();
            this.Maximum += size;
            this._partsSizes.Add(partId, size);
            this._partsProgress.Add(partId, 0);
            return partId;
        }
        public bool RemovePart(Guid partId)
        {
            double size;
            if (!this._partsSizes.TryGetValue(partId, out size))
            {
                return false;
            }
            this.Maximum -= size;
            this._partsSizes.Remove(partId);
            this.Value -= this._partsProgress[partId];
            this._partsProgress.Remove(partId);
            return true;
        }
        public bool ContainsPart(Guid partId)
        {
            return this._partsSizes.ContainsKey(partId);
        }
        public double GetProgress(Guid partId)
        {
            return this._partsProgress[partId];
        }
        public void SetProgress(Guid partId, double progress)
        {
            if (progress < 0 || this._partsSizes[partId] < progress)
            {
                throw new ArgumentOutOfRangeException("progress");
            }
            this.Value += progress - this._partsProgress[partId];
            this._partsProgress[partId] = progress;
        }
        public void AddProgress(Guid partId, double progress)
        {
            this.SetProgress(partId, progress + this._partsProgress[partId]);
        }
        [Obsolete("Not useable in ProgressBarEx.")]
        public new void PerformStep()
        {
        }
    }
