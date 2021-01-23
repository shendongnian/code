    protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
           majorVersion = Globals.ThisAddIn.Application.Version.Split(new char[] { '.' })[0];
            if (majorVersion == 12) //office 2007
            {
                 return new Ribbon2007();
            }
            else if (majorVersion >= 14) //office 2010
            {
                return new Ribbon2010();
            }
    
    
    }
    
    
    [ComVisible(true)]
    public class Ribbon2007: Office.IRibbonExtensibility
    {
        public string GetCustomUI(string ribbonID)
            {
                        var ribbonXml = GetResourceText("Ribbon2007.xml");                 
                      
        }
    }
    
    
    [ComVisible(true)]
    public class Ribbon2007: Office.IRibbonExtensibility
    {
        public string GetCustomUI(string ribbonID)
            {
                var ribbonXml = GetResourceText("Ribbon2010.xml");                 
                      
        }
    }
