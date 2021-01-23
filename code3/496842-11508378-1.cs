    #region using
        using System;
        using Castle.MonoRail.Framework;
        using campusMap.Models;
        using MonoRailHelper;
        using campusMap.Services;
    #endregion
    
    namespace campusMap.Filters
    {
        public class scriptFilter : IFilter
        {
            protected ScriptsService scriptsService = new ScriptsService();
            public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
            {
                controllerContext.PropertyBag["scriptsService"] = scriptsService;
                return true;
            }
        }
    }
