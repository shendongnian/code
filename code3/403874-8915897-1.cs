     protected void Numbers_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<int> Chosen = new List<int>();
      if (Session["Chosen"] == null)
        {
            Session["Chosen"] = new List<int>();
        } 
        Chosen = (List<int>)Session["Chosen"];
        foreach (ListItem it in Numbers.Items)
            if (it.Selected)
            {
                if (!Chosen.Contains(Convert.ToInt32(it.Text)))
                    Chosen.Add(Convert.ToInt32(it.Text));
            }
            else if (!Chosen.Contains(Convert.ToInt32(it.Text)))
                    Chosen.Remove(Convert.ToInt32(it.Text));
        foreach (int n in Chosen)
            TextBox5.Text += " item : " + n.ToString();
        
        Session["Chosen"] = Chosen;
      }
