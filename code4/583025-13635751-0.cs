    <%
    String clientTempate;
    if(Model.Active.Equals("Active"){
      clientTemplate = "<img src=\"/Content/img/delete.png\" alt=\"consultant\" title=\"consultant\" onclick=\"javascript:deleteConsultant(<#= ProjectKey #>)\"/>"
    }
    else{
      clientTemplate = "<img src=\"/Content/img/grayedout-delete.png\" alt=\"consultant\" title=\"consultant\" />"
    
    }
    %>
        
        
    <% Html.GridFor("Consultants", "Consultants", "Consultants", GridOptions.EnableSelecting, Model).Columns(column =>
                                            {
                                                column.Bound(o => o.Code).Title("Code");
                                                column.Bound(o => o.Description).Title("Description");                                  
                                             column.Bound(o => o.consultantKey).Title("").ClientTemplate(clientTemplate);
                        column.Bound(o => o.consultantKey).Hidden();
                    }).Render();            
                                        %>
