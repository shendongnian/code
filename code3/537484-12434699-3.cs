    try
    {
        RepeatCall(3, () => 
                        {
                             MyServiceCall();
                        });
    }
    catch(....)
    {
       // You'll catch here same as before since on the last try if the call
       // still fails you'll get the exception
    }
