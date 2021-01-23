	@model MvcApplication1.Controllers.MyModel
	@using (Html.BeginForm())
	{
		for (int i = 0; i < 3; i++)
		{
			string id = "txt" + i.ToString();
			
			@Html.TextBoxFor(m => m.TextFields[i], new { id = id })
		}
		
		<input type="submit" value="Post" />
		if (Model.TextFields != null)
		{
			foreach (string textField in Model.TextFields)
			{ 
				<div>Posted Field: @textField</div>
			}
		}
	}
