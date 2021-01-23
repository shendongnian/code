    // Form.cs
    public void Update() {
         // this is your update function
    }
    public void DoMathStuff() {
        MathClass m = new MathClass() { FunctionToCall = Update };
        m.DoSomeMathOperation(); // MathClass will end up calling the Update method above.
    }
