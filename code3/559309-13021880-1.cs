    /// <summary>
            /// Recursive loop to find a control
            /// </summary>
            /// <param name="rootCtl">Control whose control collection we will begin traversing in search of the 
            ///     given ID</param>
            /// <param name="Id">ID to search for</param>
            /// <returns></returns>
            public static Control FindControlRecursive(Control rootCtl, string desiredCtlID)
            {
                //Make sure this thing exists
                if (rootCtl == null)
                    return null;
    
                //See if it's the one we're after
                if (rootCtl.ID == desiredCtlID)
                    return rootCtl;
    
                //Make sure it has controls to loop over
                if (!rootCtl.HasControls())
                    return null;
    
                foreach (Control oCtl in rootCtl.Controls)
                {
                    Control FoundCtl = FindControlRecursive(oCtl, desiredCtlID);
                    if (FoundCtl != null)
                        return FoundCtl;
                }
    
                return null;
            }
