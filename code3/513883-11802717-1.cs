        private object target;
        public object Target
        {
            get { return this.target; }
            set
            {
                this.target = value;
                var array = this.target as Array;
                this.TargetValues = array ?? new[] { this.target };
            }
        }
        public Array TargetValues { get; private set; }
