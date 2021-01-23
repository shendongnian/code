    protected void cmbCulture_Click(object sender, BulletedListEventArgs e)
    {
        //Save Current Culture in Cookie- will be used in InitializeCulture in BasePage
        Response.Cookies.Add(new HttpCookie("Culture", cmbCulture.Items[e.Index].Value));
        Response.Redirect(Request.Url.AbsolutePath); //Reload and Clear PostBack Data
    }
