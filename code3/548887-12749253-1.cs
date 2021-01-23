    Protected void btnEdit_Click(Object sender , System.EventArgs e ){
        Button clickedButton = (sender)Button;
        String() argumentsSend = clickedButton.CommandArgument.ToString().Split("|");
        String backParameters;
        Response.Redirect(String.Concat("RedirectPage.aspx?user=", Server.UrlEncode(argumentsSend(0)), "&company=", Server.UrlEncode(argumentsSend(1)), True);
