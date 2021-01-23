    bool LeafEx.Evaluate() {
        return Boolean.Parse(this.Lit);
    }
    
    bool NotEx.Evaluate() {
        return !Left.Evaluate();
    }
    
    bool OrEx.Evaluate() {
        return Left.Evaluate() || Right.Evaluate();
    }
