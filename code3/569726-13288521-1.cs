    if (fileVersionInfo.FileMajorPart >= 3)
    {
        CallX();
    }
    else
    {
        CallY();
    }
    void CallX()
    {
        DependentClass.X();
    }
    void CallY()
    {
        DependentClass.Y();
    }
