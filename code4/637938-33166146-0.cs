    Fuc<double, double> Parse(string Expression)
    {
        MathParser P = new MathParser();
        Variable V = new Variable("x", 0); // The Variable you use with default value
        P.Variables.Add(V);
        P.Parse(Expression);
        return (Input) =>
            {
                V.Value = Input;
                return P.Evaluate();
            }
    }
    
