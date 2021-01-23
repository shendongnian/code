    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
    	if (myCondition == true)
    	{
    		return Globals.Factory.GetRibbonFactory().CreateRibbonManager(
    			new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new Ribbon1() });
    	}
    	else
    	{
    		return Globals.Factory.GetRibbonFactory().CreateRibbonManager(
    			new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new Ribbon2() });
    	}
    }
