    if (Session["Session"] != null)
    {
         StringCollection hodnotyState = (StringCollection)Session["Session"];
         foreach (string s in hodnotyState)
         {
             string[] sa = s.Split('|');
             ListBox1.Items.Add(new ListItem(sa[0], sa[1]);
         }
         Session.Remove("Session");
    }
