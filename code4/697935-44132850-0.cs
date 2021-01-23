    public static class SelectListExtensions
    {
    	public static SelectList SelectValue(this SelectList selectList, object value)
    	{
    		return new SelectList(selectList, "Value", "Text", value);
    	}
    }
