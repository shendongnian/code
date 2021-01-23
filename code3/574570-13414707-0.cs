    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Start()
        {
            this.Enabled = true;
        }
        
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Stop()
        {
            this.Enabled = false;
        }
