    public IType Get(int type)
    {
        switch (type)
        {
            case 1:
                if (pool1.Count == 0)
                {
                    return new MyObject1();
                }
                else
                {
                    return pool1.Pop();
                }
                break;
            case 2:
                if (pool2.Count == 0)
                {
                    return new MyObject2();
                }
                else
                {
                    return pool2.Pop();
                }
                break;
            case 3:
                if (pool3.Count == 0)
                {
                    return new MyObject3();
                }
                else
                {
                    return pool3.Pop();
                }
                break;
         }
    }
