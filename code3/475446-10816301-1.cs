    public string GetPreviousPage()
        {
            string url;
            if (PageStack != null && PageStack.Count > 0)
            {
                url = PageStack.Pop().Path;
            }
            else
            {
                url = "/default.aspx";
            }
            return Redirect(url);
        }
