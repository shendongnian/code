    class LeafEx {
        bool Evaluate() {
            return Boolean.Parse(this.Lit);
        }
    }
    
    class NotEx {
        bool Evaluate() {
            return !Left.Evaluate();
        }
    }
    class OrEx {
        bool Evaluate() {
            return Left.Evaluate() || Right.Evaluate();
        }
    }
