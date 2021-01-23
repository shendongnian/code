    /*YOUR VIEW*/
        [ExportViewToRegion("MyView", "MyRegion")]
            [Export(typeof(MyView))]
            public partial class MyView : UserControl
            { 
             ....
            }
    
    
    /*IMPLEMENTATION*/
       public interface IExportViewToRegionMetadata
        {
             string ViewName { get; }
             string TargetRegion { get; }
        }
    
        [MetadataAttribute]
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
        public class ExportViewToRegionAttribute : ExportAttribute
        {
            public ExportViewToRegionAttribute(string viewName, string targetRegion)
                : base(typeof(UserControl))
            {
                ViewName = viewType;
                TargetRegion = targetRegion;
            }
    
           
            public string ViewName { get; private set; }
            public string TargetRegion { get; private set; }
        }
    
    
        [Export(typeof(IFluentRegionManager))]
        public class FluentRegionManager : IFluentRegionManager, IPartImportsSatisfiedNotification
        {
            public IRegionManager RegionManager { get; set; }
    
            [ImportingConstructor]
            public FluentRegionManager(IRegionManager regionManager)
            {
                RegionManager = regionManager;
            }
    
            
            /*This Import will find all views in the assemble with attribute [ExportViewToRegion("ViewName", "RegionName")]*/
            [ImportMany(AllowRecomposition = true)]
            public Lazy<UserControl, IExportViewToRegionMetadata>[] Views { get; set; }
    
    
    
            private readonly List<string> _processedViews = new List<string>();
            
            private Lazy<UserControl, IExportViewToRegionMetadata> _GetViewInfo(string viewName)
            {
                return (from v in Views where v.Metadata.ViewTypeForRegion.Equals(viewName) select v).FirstOrDefault();
            }
    
            public IExportViewToRegionMetadata this[string viewName]
            {
                get
                {
                    return (from v in Views
                            where v.Metadata.ViewName.Equals(viewType, StringComparison.InvariantCultureIgnoreCase)
                            select v.Metadata).FirstOrDefault();
                }
            }
    
            public void ExportViewToRegion(string viewName)
            {
               
                if (viewName==null)
                {
                    throw new ArgumentNullException("viewName");
                }
    
                var viewInfo = _GetViewInfo(viewName);
    
                string targetRegion;
                UserControl _view;
    
                if (viewInfo != null)
                {
                    targetRegion = viewInfo.Metadata.TargetRegion;
                    _view = viewInfo.Value;
                }
                          
    
                if (string.IsNullOrEmpty(targetRegion) || _processedViews.Contains(viewName)) return;
              
                RegionManager.RegisterViewWithRegion(targetRegion,  _view.GetType());
                _processedViews.Add(viewName);
            }
    
           
            /*All required views has been discovered and imported */
            /*Loop true collection and register view with the region */
            public void OnImportsSatisfied()
            {
                foreach (var viewName in  from view in Views where !_processedViews.Contains(view.Metadata.ViewName) 
                    select view.Metadata.ViewName)
                {
                    ExportViewToRegion(viewName);
                }
            }
        }
    /* finally call IFluentRegionManager import in the bootstrapper to kick off registration*/
