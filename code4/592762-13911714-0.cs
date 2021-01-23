    <script runat="server">
     protected void GoToMobileVersion ()
     {
      Session["FullVersion"] = false;
      Server.TransferRequest(Request.Url.AbsolutePath, false);
     }
    </script>
