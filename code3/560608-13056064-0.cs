    private bool hasPassed;
    public void HasPassed()
    {
        if (yearMark < 40)
        {
            hasPassed = false;
        }
        else
        {
            hasPassed = true;
        }
    }
    public void Main()
    {
        HasPassed();
        if (hasPassed)
        {
             //Do something
        }
    }
