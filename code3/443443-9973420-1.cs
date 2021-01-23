            using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    public class MyHTTPHandler : IHttpHandler, IRequiresSessionState
    {
    
    string myFile;
    public bool IsReusable {
    	get { return true; }
    }
    
    public void ProcessRequest(System.Web.HttpContext context)
    {
    	myFile = context.Request.Path;
    	if (myFile.ToLower().Contains("members private files") || myFile.ToLower().Contains("members%20private%20files")) {
    		if (System.Web.HttpContext.Current.Session["Login"] == null) {
    			context.Response.Redirect("~/NotAuthorized.aspx");
    		} else {
    			if (myFile.ToLower().Contains("privatefiles")) {
    				StartDownload(context, myFile);
    			} else {
    				if (IsMemberAuthoraizedToDownloadFile(context)) {
    					StartDownload(context, myFile);
    				} else {
    					context.Response.Redirect("~/NotAuthorized.aspx");
    				}
    			}
    		}
    	} else {
    		StartDownload(context, myFile);
    	}
    }
    
    private void StartDownload(HttpContext context, string downloadFile)
    {
    	context.Response.Buffer = true;
    	context.Response.Clear();
    	context.Response.AddHeader("content-disposition", "attachment; filename=" + downloadFile);
    	context.Response.ContentType = "application/pdf";
    	context.Response.WriteFile(downloadFile);
    }
    
    // just my own function to check if user is valid
    private bool IsMemberAuthoraizedToDownloadFile(HttpContext context)
    {
    	GroupMembersControl MyGroupMemberc = new GroupMembersControl();
    	System.Collections.Generic.List<GroupMembers> MemberGroupsL = MyGroupMemberc.GetMemberGroups(System.Web.HttpContext.Current.Session["Login"]);
    	MemberGroupControl MyGroupC = new MemberGroupControl();
    	MemberGroup MyGroup = default(MemberGroup);
    	foreach (GroupMembers groupmember in MemberGroupsL) {
    		MyGroup = MyGroupC.GetMemberGroup(groupmember.GroupID);
    		if (myFile.ToLower().Contains(MyGroup.Name.ToLower)) {
    			return true;
    		}
    	}
    	return false;
    }
        }
