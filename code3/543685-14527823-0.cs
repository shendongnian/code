    <%@ WebHandler Language="C#" Class="Menus" %>
    using System;
    using System.Web;
    
    
    using System.Text;
    using System.Xml;
    using System.IO;
    using System.Globalization;
    
    using DotNetNuke.Common;
    using DotNetNuke.Common.Utilities;
    using DotNetNuke.Entities.Portals;
    using DotNetNuke.Entities.Tabs;
    using DotNetNuke.Security.Permissions;
    using System.Collections.Generic;
    
    
    public class Menus : IHttpHandler {
        
    public void ProcessRequest (HttpContext context) {
	
	
	string cc = PortalAliasController.GetPortalAliasByTab(Int32.Parse(context.Request.Params["tabid"]),"");
	PortalAliasInfo pa = PortalAliasController.GetPortalAliasInfo(cc);
	int portalid = pa.PortalID;
	PortalSettings ps = new PortalSettings(portalid);
	int tabid = ps.HomeTabId;  
	if (!String.IsNullOrEmpty(context.Request.Params["tabid"]))
		tabid = Int32.Parse(context.Request.Params["tabid"]);  
	
	XmlWriterSettings ws = new XmlWriterSettings();
	ws.Indent = true;
	ws.Encoding = Encoding.UTF8;
        XmlWriter xw = XmlWriter.Create(context.Response.OutputStream, ws);
        context.Response.ContentType = "text/xml";
	xw.WriteStartElement("root");
    xw.WriteElementString("portalid", portalid.ToString());
    MakeMenu(context, xw, tabid, portalid);
	xw.WriteEndElement();
	xw.Close();
	
	        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
   
    private void MakeMenu(HttpContext context, XmlWriter xw, Int32 tabid, Int32 portalid)
    {
        
        
        List<TabInfo> tabs = TabController.GetTabsByParent(tabid, portalid);
        if (tabs.Count == 0) return;
        
        
        
        foreach (TabInfo objTab in tabs)
        {
            
            if (!objTab.IsDeleted &&
              !objTab.DisableLink &&
              objTab.IsVisible &&
              objTab.TabType == TabType.Normal &&
              (Null.IsNull(objTab.StartDate) || objTab.StartDate < DateTime.Now) &&
              (Null.IsNull(objTab.EndDate) || objTab.EndDate > DateTime.Now)
            )
            {
                if (TabPermissionController.CanViewPage(objTab))
                {
                  
                    string tabName = objTab.TabName;
                    string URL = objTab.FullUrl;
                    
                  if (URL.ToLower().IndexOf(context.Request.Url.Host.ToLower()) == -1) ;
                    
                  URL = Globals.AddHTTP(context.Request.Url.Host) + URL;
                    
                  xw.WriteStartElement("menu");
                  xw.WriteAttributeString("text", tabName);
                  xw.WriteAttributeString("url", URL);
                  MakeMenu(context, xw, objTab.TabID, portalid);
                  xw.WriteEndElement();
                }
            }
 
        }
  
    }
   
}
