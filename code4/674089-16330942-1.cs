        ad_index += 5;
        for (int i = 0; i < upload_index; i++)
        {
            try
            {
                SSImage img = images[i];
                HyperLink imglink = new HyperLink();
                imglink.NavigateUrl = "/Image.aspx?id=" + img.id;
                imglink.ImageUrl = "/ShowImage.ashx?imgid=" + img.id;
                imglink.ToolTip = img.title;
                imglink.CssClass = "imgupload";
                // Commented old code
                //Control contentpanel = RecentUpload.ContentTemplateContainer;
                //contentpanel.Controls.AddAt(contentpanel.Controls.Count - 2, imglink);
                //Add controls to Panel instead of updating the ContentTemplate itself
                pnlMyDynamicContent.Controls.AddAt(pnlMyDynamicContent.Controls.Count - 2, imglink);
            }
            catch (ArgumentOutOfRangeException)
            {
                loaduploads.Visible = false;
                break;
            }
        }
