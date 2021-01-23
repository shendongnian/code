    protected void btnSort_Click1(object sender, EventArgs e)
    {
        if (dropListActivity.SelectedIndex > 0)// drop down list
        {
            var actId = Convert.ToInt32(dropListActivity.SelectedItem.Value);
            var imageUrl = daoStory.GetFileUrl(actId);
            Response.Write(imageUrl);
        } 
    }
