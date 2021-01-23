    if (this.IsThemeDictionary || this._ownerApps != null || this.IsReadOnly)
	{
		StyleHelper.SealIfSealable(value);
	}
    ... 
    internal static void SealIfSealable(object value)
    {
	ISealable sealable = value as ISealable;
	if (sealable != null && !sealable.IsSealed && sealable.CanSeal)
	{
		sealable.Seal();
	}
    }
