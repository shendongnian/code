    [HandleProcessCorruptedStateExceptions]
    protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool flag1)
    {
        if (flag1)
        {
            try
            {
                this.~CppDispose();
            }
            finally
            {
                base.Dispose(true);
            }
        }
        else
        {
            try
            {
                this.!CppDispose();
            }
            finally
            {
                base.Dispose(false);
            }
        }
    }
    protected override void Finalize()
    {
        this.Dispose(false);
    }
