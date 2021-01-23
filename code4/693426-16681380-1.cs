      protected void Button2_Click(object sender, EventArgs e)
        {
    
            if (Session["myList"] == null)
                Session["myList"] = new List<string>();
    
            List<string> myList = (List<string>)Session["myList"];
    
            txtItemListCount.Text = myList.Count.ToString();
        }
