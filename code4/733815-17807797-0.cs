    public class CustomViewEngine : RazorViewEngine
    {
    	protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    	{
    		var view = base.CreatePartialView(controllerContext, partialPath);
    
    		return new ViewWrapper(view);
    	}
    
    	protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    	{
    		var view = base.CreateView(controllerContext, viewPath, masterPath);
    
    		return new ViewWrapper(view);
    	}
    }
    
    public class ViewWrapper : IView
    {
    	protected IView View;
    
    	public ViewWrapper(IView view)
    	{
    		View = view;
    	}
    
    	public void Render(ViewContext viewContext, TextWriter writer)
    	{
    		//Type modelType = BuildManager.GetCompiledType(razorView.ViewPath);
    		var razorView = View as RazorView;
    
    		if (razorView != null)
    		{
    			//if we could not get the model object - try to get it from what is declared in view
    			var compiledViewType = BuildManager.GetCompiledType(razorView.ViewPath);
    
    			var model = viewContext.ViewData.Model;
    
    			Type baseType = compiledViewType.BaseType;
    			//model is passed as generic parameter, like this MyView1 : WebViewPage<MyModel1>
    			if (baseType != null && baseType.IsGenericType)
    			{
    				//and here the trick begins - extract type of model from generic arguments
    				var modelType = baseType.GetGenericArguments()[0]; //the same as typeof(MyModel1)
    
    				// ReSharper disable UseMethodIsInstanceOfType
    				//If model is null, or model is not type of the given model (for partials)
    				if (model == null || !modelType.IsAssignableFrom(model.GetType()))
    				// ReSharper restore UseMethodIsInstanceOfType
    				{
    					//Set @model and render the view
    					viewContext.ViewData.Model = Activator.CreateInstance(modelType);
    				}
    			}
    		}
    
    		View.Render(viewContext, writer);
    	}
    }
