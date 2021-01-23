            if (Session.Contents.Count == 0)
            {
                Response.Write(".NET session has Expired");
                Response.End();
            }
            else
            {
                InitializeControls();
            }
