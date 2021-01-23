     <div id="hiddenContent2" runat="server"> 
            <%# Eval("ReportID") %>
     </div>
     foreach (RepeaterItem item in rptReports.Items)
     {
         System.Web.UI.HtmlControls.HtmlGenericControl hiddenContent2 = (System.Web.UI.HtmlControls.HtmlGenericControl)item.FindControl("hiddenContent2");
         string ReportID = hiddenContent2.InnerHtml;
     }
