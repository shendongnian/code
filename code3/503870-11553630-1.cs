        protected void cv_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = false;
            foreach (ListItem item in this.lb.Items)
            {
                if (item.Selected)
                {
                    if (item.Text.ToLower().Trim() == "questiontext1")
                    {
                        e.IsValid = true;
                        break;
                    }
                }
            }
        }
