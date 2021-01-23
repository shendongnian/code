    class Function {
        protected abstract void SetData(int n);
    }
    class Push : Function {
        int Friction;
    
        protected override void SetData(int n) {
            this.Friction = n; 
        }
    }
    class Lift : Function {
        int Gravity;
    
        protected override void SetData(int n) {
            this.Gravity= n; 
        }
    }
        
