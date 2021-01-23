    StringBuilder _StrB = new StringBuilder();
        if (Request.QueryString["id"] != null)
        {
            str_query = "select top(5) image from tbl_product_images where productinfo_id='" + Request.QueryString["id"].ToString() + "'";
            dt_Common = new CommonClass().bind_department(str_query);
            if (dt_Common.Rows.Count> 0)
            {
                for (int i = 0; i < dt_Common.Rows.Count; i++)
                {
                    image.Src = dt_Common.Rows[i]["image"].ToString().Replace("~", "..");
                    _StrB.Append("<a id=" + i + " class=\"activeborder\" data-image=" + dt_Common.Rows[i]["image"].ToString() + " data-zoom-image=" + dt_Common.Rows[i]["image"].ToString() + "><img src=" + dt_Common.Rows[i]["image"].ToString() + " /></a>");
                }
                
            }
            string AllHTMLImages = _StrB.ToString().Replace("~", "..");
            div_images.InnerHtml = AllHTMLImages;
        }
        else
        {
        }
