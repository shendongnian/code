    public class MultiTenancyRazorViewEngine : RazorViewEngine
	{
		/// <summary>
		/// Finds the specified partial view by using the specified controller context.
		/// </summary>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="partialViewName">The name of the partial view.</param>
		/// <param name="useCache">true to use the cached partial view.</param>
		/// <returns>The partial view.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="controllerContext"/> parameter is null (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="partialViewName"/> parameter is null or empty.</exception>
		public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
		{
			var searchedLocations = new List<string>();
			var foundFile = Support.ResolvePath(string.Format("{0}.cshtml", partialViewName), controllerContext.HttpContext, controllerContext.RouteData, searchedLocations);
			return foundFile == null 
				? new ViewEngineResult(searchedLocations) 
				: base.FindPartialView(controllerContext, foundFile, useCache);
		}
		/// <summary>
		/// Finds the view.
		/// </summary>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="viewName">Name of the view.</param>
		/// <param name="layoutPath">The layout path.</param>
		/// <param name="useCache">if set to <c>true</c> [use cache].</param>
		/// <returns></returns>
		public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string layoutPath, bool useCache)
		{
			var searchedLocations = new List<string>();
			var foundFile = Support.ResolvePath(string.Format("{0}.cshtml", viewName), controllerContext.HttpContext, controllerContext.RouteData, searchedLocations);
			return foundFile == null 
				? new ViewEngineResult(searchedLocations) 
				: base.FindView(controllerContext, foundFile, layoutPath, useCache);
		}
