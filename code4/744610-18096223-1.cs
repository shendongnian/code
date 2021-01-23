    System.Web.UI.WebControls.LinkButton lbView = new System.Web.UI.WebControls.LinkButton();
    lbView.Text = "<br />" + "View";
    btn.OnClientClick = "return RedirectTo();";  // You need to add javascript event
    
    tc.Controls.Add(lbView);
    tr.Cells.Add(tc);
    
    
    // javascript
    <script>
      function RedirectTo()
      {
         window.location.href = 'contactus.aspx';
         return false;
      }
    </script>
    
    
