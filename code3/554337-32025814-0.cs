    bool toggleTabPageVisibility(TabControl tc, TabPage tp)
    {
        //if tp is already visible
        if (tc.TabPages.IndexOf(tp) > -1)
        {
            tc.TabPages.Remove(tp);
            //no pages to show, hide tabcontrol
            if(tc.TabCount == 0)
            {
                tc.Visible = false;
            }
            return false;
        }
        //if tp is not visible
        else
        {
            tc.TabPages.Insert(tc.TabPages.Count, tp);
            //guarantee tabcontrol visibility
            tc.Visible = true;
            tc.SelectTab(tp);
            return true;
        }
    }
