    [ToolboxItemAttribute(false)]
    public class MyWebPart : Microsoft.SharePoint.WebPartPages.WebPart
    {
    
        [Personalizable(), WebBrowsable, Category("GPWF Settings")]
        public string WebClientUrl { get; set; }
    
    }
