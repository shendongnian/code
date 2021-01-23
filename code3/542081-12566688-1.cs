    private ClassA A { get; set; }
    public ClassB()
    {
        this.A = new ClassA();
        this.A.OnProcessed += new ClassA.DelegateProcessed(this.ClassA_Processed);
    }
