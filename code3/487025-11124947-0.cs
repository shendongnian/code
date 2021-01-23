    // Declaring the interface
    interface FuncDouble {
        double calculate();
    }
    public LevenbergMarquardt(FuncDouble[] regressionFunctions, ...) {
        // Using the functor:
        double functionValue = _regressionFunctions[i].calculate()
    }
    // Declaring an array of functors:
    FuncDouble[] regressionFunctions = new FuncDouble[] {
        new FuncDouble() {
            public claculate() {
                return A * Math.Exp(time) * Math.Sin(B * time);
            }
        }
    ,   new FuncDouble() {
            public claculate() {
                return C * Math.Exp(time) * Math.Cos(D * time);
            }
        }
    };
