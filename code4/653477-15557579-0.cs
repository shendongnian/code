    class YourControl {
        public event EventHandler Success;
        
        protected void OnSuccess() {
            if(this.Success != null)
                this.Success(this, EventArgs.Empty);
        }
    }
