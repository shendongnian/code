    protected void btnDoRegister_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
         C# code is here doing form processing
         // Now I need to Execute javascript here.
         string script = "<script> functionToExecute(); </script>";
         ClientScript.RegisterClientScriptBlock(this.GetType(), "myscript", script);
    }
