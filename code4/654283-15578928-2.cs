    public interface ISocialMediaWidget
    {
        ISocialMediaWidgetResponse DoSomeUnitOfWork();
    }
    
    
    public class ConcreteSocialMediaWidgetService
    {
        protected readonly ISocialMediaWidget socialMediaWidget;
    
        public ConcreteSocialMediaWidgetService(ISocialMediaWidget widget)
        {
            this.socialMediaWidget = widget;
        }
    
        public ISocialMediaWidgetResponse Foo()
        {
            return socialMediaWidget.DoUnitOfWork();
        }
    }
