    HtmlGenericControl liTab = new HtmlGenericControl("li");                        
    HtmlGenericControl anTab = new HtmlGenericControl("a");
    anTab.Attributes.Add("href", "#Tab1");
    anTab.InnerText = "Tab1";
    liTab.Controls.Add(anTab);
    ulSections.Controls.Add(liTab);
    var pnl = new Panel();
    pnl.ID = "Tab1";
    pnlTabs.Controls.Add(pnl);
