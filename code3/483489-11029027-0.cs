    <%
        if(grid!=null)
        {
           try
           {
               var myList=(DropDownList)this.grid.FindControl("SRPType");
               if (myList!=null)
                   Response.Write( myList.ClientID);
               else
                   Response.Write("Where's my listbox?");
           }
           catch(Exception exc)
           {
              //Report error, maybe warn user
           }
        }
    %>
