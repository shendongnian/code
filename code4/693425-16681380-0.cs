    Session["myList"] = myList;
  
      protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["myList"] == null)
                Session["myList"] = new List<string>(); // Check that it exists
    
            List<string> myList = (List<string>)Session["myList"]; // Cast and add to your list
            myList.Add(txtItem.Text);
    
            Session["myList"] = myList; // Update the list
    
            txtItem.Text = "";
        }
