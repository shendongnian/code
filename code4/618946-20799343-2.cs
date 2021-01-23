        public void FocusMyCustomRibbonTab()
        {
            if (IsExcel2007())
            {
                Globals.Ribbons.GetRibbon<MyRibbon>().tabMyRibbonTab.KeyTip = "GGG";
                
                //Excel 2007: Must send "ALT" key combination to activate tab, here "GGG"
                SendKeys.Send("%");                       
                SendKeys.Send("{G}");                     
                SendKeys.Send("{G}");                     
                SendKeys.Send("{G}");                     
                SendKeys.Send("%");                       
            }
            else
            {
                //Excel 2010 or higher: Build in way to activate tab
                if (this.ribbon.RibbonUI != null)
                {
                    this.ribbon.RibbonUI.ActivateTab("MY_RIBBON_TAB_NAME");
                }
            }
        }
        public static bool IsExcel2007()
        {
            return (Globals.ThisAddIn.Application.Version.StartsWith("12"));
        }
