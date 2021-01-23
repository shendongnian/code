        protected List<string> SelectedSongs
        {
            get
            {
                List<string> li = new List<string>();
                if (Session["SelectedSongs"] != null)
                {
                    try
                    {
                        return (List<string>)Session["SelectedSongs"];
                    }
                    catch (Exception e)
                    {
                        return li; // Something went wrong?  Return the empty list.
                    }
                }
                else
                {
                    return li;
                }
            }
            set
            {
                Session["SelectedSongs"] = value;
            }
        }
