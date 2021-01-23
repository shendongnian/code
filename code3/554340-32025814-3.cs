    void setTabPageVisibility(TabControl tc, TabPage tp, bool visibility)
    {
        //if tp is not visible and visibility is set to true
        if ((visibility == true) && (tc.TabPages.IndexOf(tp) <= -1))
        {
            tc.TabPages.Insert(tc.TabCount, tp);
            //guarantee tabcontrol visibility
            tc.Visible = true;
            tc.SelectTab(tp);
        }
        //if tp is visible and visibility is set to false
        else if ((visibility == false) && (tc.TabPages.IndexOf(tp) > -1))
        {
            tc.TabPages.Remove(tp);
            //no pages to show, hide tabcontrol
            if(tc.TabCount == 0)
            {
                tc.Visible = false;
            }
        }
        //else do nothing
    }
