    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject() {
                OwnRibbon ribbon = new OwnRibbon();
                ribbon.SomeProperty = //get the document here
                return ribbon;
            }
