    private bool MoveNext()
    {
        bool CS$1$0000;
        try
        {
            int CS$4$0001 = this.<>1__state;
            if (CS$4$0001 != 0)
            {
                if (CS$4$0001 != 3)
                {
                    goto Label_00AB;
                }
                goto Label_0074;
            }
            this.<>1__state = -1;
            this.<filestream>5__1 = new FileStream(this.filename, FileMode.Open);
            this.<>1__state = 1;
            this.<reader>5__2 = new StreamReader(this.<filestream>5__1);
            this.<>1__state = 2;
            while ((this.<line>5__3 = this.<reader>5__2.ReadLine()) != null)
            {
                this.<>2__current = new YourObject(this.<line>5__3);
                this.<>1__state = 3;
                return true;
            Label_0074:
                this.<>1__state = 2;
            }
            this.<>m__Finally5();
            this.<>m__Finally4();
        Label_00AB:
            CS$1$0000 = false;
        }
        fault
        {
            this.System.IDisposable.Dispose();
        }
        return CS$1$0000;
    }
    void IDisposable.Dispose()
    {
        switch (this.<>1__state)
        {
            case 1:
            case 2:
            case 3:
                try
                {
                    switch (this.<>1__state)
                    {
                        case 2:
                        case 3:
                            break;
    
                        default:
                            break;
                    }
                    try
                    {
                    }
                    finally
                    {
                        this.<>m__Finally5();
                    }
                }
                finally
                {
                    this.<>m__Finally4();
                }
                break;
        }
    }
