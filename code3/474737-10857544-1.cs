        // C:\Program Files\Microsoft SDKs\Windows\v7.1\Include\UIAutomationClient.h
        public const int UIA_LegacyIAccessibleNamePropertyId = 30092;
        public const int UIA_LegacyIAccessibleValuePropertyId = 30093;
        public const int UIA_IsTextPatternAvailablePropertyId = 30040;
        public const int UIA_IsItemContainerPatternAvailablePropertyId = 30108;
        public const int UIA_AutomationIdPropertyId = 30011;
        public const int UIA_NamePropertyId = 30005;
        public const int UIA_IsInvokePatternAvailablePropertyId = 30031;
        public const int UIA_ItemContainerPatternId = 10019;
        public const int UIA_TextPatternId = 10014;
        public const int UIA_LegacyIAccessiblePatternId = 10018;
        public const int UIA_ValuePatternId = 10002;
        public const int UIA_InvokePatternId = 10000;
        public const int UIA_ButtonControlTypeId = 50000;
            uiAutomationCore = new UiAutomationCore();
            cacheRequest = UiAuto.CreateCacheRequest();
            cacheRequest.AddPattern(WindowsConstants.UIA_LegacyIAccessiblePatternId);
            cacheRequest.AddProperty(WindowsConstants.UIA_LegacyIAccessibleNamePropertyId);
                       
           cacheRequest.AddProperty(WindowsConstants.UIA_LegacyIAccessibleValuePropertyId);
            cacheRequest.TreeFilter = UiAuto.ContentViewCondition;
            trueCondition = UiAuto.CreateTrueCondition();
    // A Pinvoke GetChildWindows call because it is 
    // the fastest way to traverse down to a handle
    foreach (var child in GetChildWindows(someIUIAutomationElement.GetMainWindowHandle()))
            {
                var sb = new StringBuilder(100);
                // get the name of each window & see if it is an ultragrid
                // (get the name because the getchildwindows call only gets the handles
                User32.GetClassName(child, sb, sb.Capacity);
                var foundProperGrid = false;
                if (Win32Utils.GetText(child) != "UltraGrid1")
                    continue;
                // if this is an ultragrid, create a core automation object
                var iuiae = UiCore.AutoElementFromHandle(child);
                // get the children of the grid
                var outerArayOfStuff =
                    iuiae.FindAllBuildCache(interop.UIAutomationCore.TreeScope.TreeScope_Children,
                                            trueCondition,
                                            cacheRequest.Clone());
                var countOuter = outerArayOfStuff.Length;
                // loop through the grid children 
                for (var counterOuter = 0; counterOuter < countOuter; counterOuter++)
                {
                    // make a core automation object from each
                    var uiAutomationElement = outerArayOfStuff.GetElement(counterOuter);
                    // hacky - see if this grid has a GroupBy Box as first 'row'
                    //       - if so, this is the proper grid
                    //       - ignore other grids
                    if (!foundProperGrid && uiAutomationElement.CurrentName.Equals("GroupBy Box"))
                    {
                        foundProperGrid = true;
                    }
                    else if (foundProperGrid)
                    {
                        // 'cast' the object to a core 'legacy msaa' object
                        IUIAutomationLegacyIAccessiblePattern outerLegacyPattern =
                            uiAutomationElement.GetCachedPattern(WindowsConstants.UIA_LegacyIAccessiblePatternId);
                        Log.Info("OUTER, CachedName = " + outerLegacyPattern.CachedName);
                            
                        try
                        {
                            // select the 'row' to give visual feedback
                            outerLegacyPattern.Select(3);
                        }
                        catch (Exception exc)
                        {
                            Log.Info(exc.Message);
                        }
                        // get the cells in a row
                        var arrayOfStuff =
                            uiAutomationElement.FindAllBuildCache(TreeScope.TreeScope_Children,
                                                                    trueCondition,
                                                                    cacheRequest.Clone());
                        // loop over the cells in a row
                        var count = arrayOfStuff.Length;
                        for (var counter = 0; counter < count; counter++)
                        {
                            // get a cell
                            var currIUIA = arrayOfStuff.GetElement(counter);
                            // 'cast' cell to a core 'legacy msaa' object
                            IUIAutomationLegacyIAccessiblePattern legacyPattern =
                                currIUIA.GetCachedPattern(WindowsConstants.UIA_LegacyIAccessiblePatternId);
                            // dump cell name & value for reference
                            var name = legacyPattern.CachedName;
                            Log.Info(counter + ") CachedName = " + name);
                            var value = legacyPattern.CachedValue;
                            Log.Info("CachedValue = " + value);
                            // check if cell name corresponds to what is being checked
                            if (name.Equals("Date"))
                            {
                                //if (!value.StartsWith("5/23/2012"))
                                if (!value.StartsWith("5/25/2012"))
                                    errorList.AppendLine("Bad Date = " + value);
                            }
                            if (name.Equals("XXX"))
                            {
                                if (!(value.Equals("1") || value.Equals("2")))
                                    errorList.AppendLine("Bad XXX= " + value);
                            }
                            if (name.Equals("YYY"))
                            {
                                if (!value.Equals("ZZZ"))
                                    errorList.AppendLine("Bad YYY = " + value);
                            }
                        }
                    }
                }
                foundProperGrid = false;
            }
            var stopTime = DateTime.Now;
            var duration = stopTime - startTime;
            Log.Info("duration = " + duration);
            if (!"".Equals(errorList.ToString()))
            {
                Log.Info("errorList = " + errorList);
                Assert.Fail("Test errors");
            }
        }
