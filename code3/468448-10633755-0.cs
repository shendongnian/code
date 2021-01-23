            if (grvSender.ID == "gvA")
            {
                if (!IsPostBack)
                    gvB.DataBind();
            }
            else
            {
                if (IsPostBack)
                    gvB.DataBind();
            }
