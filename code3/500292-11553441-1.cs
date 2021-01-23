    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class CustomPageHttpModule : IHttpModule
    {
    
    
    	public void Dispose()
    	{
    	}
    
    	public void Init(System.Web.HttpApplication context)
    	{
    		context.BeginRequest += Application_PreRequest;
    	}
    
    	private void Application_PreRequest(object source, EventArgs e)
    	{
    		SPSecurity.RunWithElevatedPrivileges(GetRequestedPage);
    	}
    
    	private void GetRequestedPage()
    	{
    		try {
    			string RequestedURL = HttpContext.Current.Request.Url.ToString;
    			//Do only when the requested page is aspx.
    			if (System.IO.Path.GetExtension(RequestedURL).ToLower() == ".aspx") {
    				using (SPSite Site = new SPSite(RequestedURL)) {
    					using (SPWeb objWeb = Site.OpenWeb()) {
    						SPFile RequestedPage = objWeb.GetFile(RequestedURL);
    						if (RequestedPage != null && RequestedPage.Exists && (RequestedPage.MajorVersion == 0)) {
    							HttpContext.Current.Response.Redirect("/_layouts/Pages/custom404page.aspx");
    						}
    					}
    				}
    			}
    		} catch (Exception ex) {
    			throw;
    		}
    	}
    }
