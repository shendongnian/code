    private void repeatedSetupCode(int someVal, string someOtherVal)
    {
      someMember = someVal;
      someOtherMember = someOtherVal;
    }
    public A(int someVal, string someOtherVal)
    {
      repeatedSetupCode(someVal, someOtherVal);
    }
    public A(int someVal)
    {
      repeatedSetupCode(someVal, null);
    }
    public A()
    {
      repeatedSetupCode(0, null);
    }
