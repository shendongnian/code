    public void Test1()
    {
        decimal[][] originalFormTableau = CreateOriginalFormTableau();
        decimal[][] standardFormTableau = InsertSlackVariables(originalFormTableau);
        this.Engine = new SimplexEngine(standardFormTableau, normalizationThreshold);
    }
