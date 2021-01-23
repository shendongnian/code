    <form id="form1" runat="server">
        <div>
            This is some HTML. The current time is:
            <%
                System.Diagnostics.Debugger.Break();
                Session["CurrentTime"] = DateTime.Now;
            %>
        </div>
        <%
            System.Diagnostics.Trace.WriteLine(Session["CurrentTime"]);
            System.Diagnostics.Debug.WriteLine(Session["CurrentTime"]);
            System.Diagnostics.Debugger.Break();
            Response.Write(Session["CurrentTime"]);
            Response.Write("<br/>");
        %>
        You should see the current date above this line.
    </form>
