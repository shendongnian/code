    foreach (Control c in this.Controls)
    {               
            if (c.GetType().Name.ToString()=="TextBox")
           {
                    totalValue += int.Parse(String.Format("txtBox{0}.Text", count));
           }
    }
