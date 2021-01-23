    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject() {
                OwnRibbon ribbon = new OwnRibbon();
                ribbon.DocumentProperty = //get the document here
                return ribbon;
            }
