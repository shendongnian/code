    if (!IsPostBack)
                    {
                        try
                        {
                            if (Session["user.transaction.id"] != null && !string.IsNullOrEmpty(Session["user.transaction.id"].ToString()))
                            {
                                Label1.Text = Session["user.transaction.id"].ToString(); //Error Line
                            }
    
                        }
                        catch (Exception a8)
                        {
                            Label1.Text = a8.Message;
                        }
                    }
