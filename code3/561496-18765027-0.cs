    string content;
    ViewData.Model = model;
    using (var writer = new System.IO.StringWriter())
    {
    	var context = new ViewContext(ControllerContext, view.View, ViewData, TempData, writer);
    	view.View.Render(context, writer);
    	writer.Flush();
    	content = writer.ToString();
    	writer.Close();
    }
