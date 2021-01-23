    public void VerifyAccess()
{
	if (!this.CheckAccess())
	{
		throw new InvalidOperationException(SR.Get("VerifyAccess"));
	}
