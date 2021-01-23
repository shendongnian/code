    #region Directives 
        using Castle.MonoRail.Framework; 
        using campusMap.Services; 
        using campusMap.Models; 
        using Castle.ActiveRecord; 
        using MonoRailHelper; 
        using campusMap.Filters; 
        //any others you'd need
    #endregion 
    namespace campusMap.Controllers 
    { 
        [Filter(ExecuteWhen.BeforeAction, typeof(scriptFilter))] 
        [Layout("default"), Rescue("generalerror")] 
        public abstract class BaseController : MonoRailHelper.HelperBaseController 
        { 
            protected ScriptsService ScriptsService = new ScriptsService();
        } 
    }
