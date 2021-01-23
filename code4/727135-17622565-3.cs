    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool AddPage(this TabControl tc, TabPage tp)
            {
                var matchedPages = tc.Controls.Find(tp.Name, false);
                if ( matchedPages.Length > 0)
                {
                    tc.SelectedTab = (TabPage)matchedPages[0];
                    return true;
                }
                else
                {
                    tc.TabPages.Add(tp);
                    tc.SelectedTab = tp;
                    return false;
                }
           
            }
        }
    }
