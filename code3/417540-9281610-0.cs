    //THIS ADDS THE <A> to the <LI>
    liTab.Controls.Add(anTab);
    //THIS ADDS THE <LI> to the <UL>
    ulSections.Controls.Add(liTab);
    
    //THIS CODE Appear to have nothing to do with anything.
    var pnl = new Panel();
    pnl.ID = Tab1;
    pnlTabs.Controls.Add(pnl);
