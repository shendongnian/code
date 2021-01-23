    private void VerifyPropertyName(string PropertyName)
    {
    	if (string.IsNullOrEmpty(PropertyName))
    		return;
    	if (TypeDescriptor.GetProperties(this)(PropertyName) == null) {
    		string msg = "Ungültiger PropertyName: " + PropertyName;
    		if (this.ThrowOnInvalidPropertyName) {
    			throw new isgException(msg);
    		} else {
    			Debug.Fail(msg);
    		}
    	}
    }
