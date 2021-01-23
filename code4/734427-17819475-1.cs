    public Step : UserControl {
        ....
        public virtual void StopTimeOut() {
             //BASE IMPLEMENTATION
        }
    }
    
    public Step1 : Step {
        public override void StopTimeOut() {
             //CHILD IMPLEMENTATION
        }
    }
    
    public Step2 : Step {
        public override void StopTimeOut() {
             //CHILD IMPLEMENTATION
        }
    }
    ..
