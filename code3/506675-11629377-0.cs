    public override void ExecuteResult(ControllerContext context)
    {
      if (context == null)
        throw new ArgumentNullException("context");
      if (string.IsNullOrEmpty(this.ViewName))
        this.ViewName = context.RouteData.GetRequiredString("action");
      ViewEngineResult viewEngineResult = (ViewEngineResult) null;
      if (this.View == null)
      {
        viewEngineResult = this.FindView(context);
        this.View = viewEngineResult.View;
      }
      TextWriter output = context.HttpContext.Response.Output;
      this.View.Render(new ViewContext(context, this.View, this.ViewData, this.TempData, output), output);
      if (viewEngineResult == null)
        return;
      viewEngineResult.ViewEngine.ReleaseView(context, this.View);
    }
