    protected virtual void OnNumberReached(NumberReachedEventArgs e)
    {
        //If number reached is changed from after this check
        if(NumberReached != null)
        {
            //and between this call, it could still result in a
            //NullReferenceException
            NumberReached(this, e);
        }
    }
