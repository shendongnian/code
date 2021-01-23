    public void function1(a, num)
    {
        if (a < num)
        {
            function2(a, num);
        }
        else
        {
            function1((a > num) ? a : a + 1, num);
        }
    }
    
    public void function2(a, num)
    {
        //print result;
    }
