        public void FocusMyCustomRibbonTab()
        {
            if (IsExcel2007())
            {
                //Excel 2007: Must send "ALT" key combination to activate tab, here "Y2"
                SendKeys.SendWait("%");                       //MLHIDE
                SendKeys.SendWait("{Y}");                     //MLHIDE
                SendKeys.SendWait("{2}");                     //MLHIDE
                SendKeys.SendWait("%");                       //MLHIDE
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
