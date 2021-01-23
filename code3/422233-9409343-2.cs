            if (c.GetType().Name.ToString()=="TextBox")
           {
                    totalValue += int.Parse(String.Format("txtBox{0}.Text", count));
           }
    }</strike>
    foreach (Control c in this.Controls)
    {               
            if (c.GetType().Name.ToString()=="TextBox")
           {
                    int value = 0;
                    if(int.TryParse(((TextBox)c).Text,out value))
                         totalValue += value;
           }
    }
