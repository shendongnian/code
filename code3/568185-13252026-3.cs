    Kernel.InterceptReplace<Foo>(foo => foo.ThrowsAnError(),
        invocation =>
        {
            try
            {
                // calls the decorated instance with supplied parameters
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Kernel.Get<ILogger>().Log(ex);
            }
        } );
