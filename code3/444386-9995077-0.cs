    <%
        // this part is blocked as it is, after the post back
        if (Page.IsPostBack)
        {
            int n = int.Parse(Request.Params["number"]);
            string name = Request.Params["fname"];
            int points = CalcPoints(name, n);
         %>
         Hello <%=name%> You have chosen number <%=n%>
         The random numbers are : <%=num1 + " , " + num2 + " , " + num3%>
         You have scored <%=points%> points!
         <%
        }
        %>
