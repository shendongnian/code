    [When("I run the program (\d+) times")]
    public void WhenIRunTheProgramManyTimes(int count)
    {
        for(int i=0; i++; i<count)
        WhenIRunTheProgram();
    }
    [When("I run the program")]
    public void WhenIRunTheProgram()
    {
       ....
