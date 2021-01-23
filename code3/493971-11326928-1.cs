    @using (Html.BeginForm("MyStep1", "Wizard"))
    {
    	var properties = new Dictionary<string, object>();
    	ReflectionHelper.IterateProps(Model, Model.GetType().Name,ref properties);
    	foreach (var property in properties)
    	{
    		<input type="hidden" name="@property.Key" value="@property.Value"/>
    	}
    }
