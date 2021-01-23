    if (ListBox2.Items.Count >= 0)
    {
        sql = sql + " and ( MotherTongue = 'xyz'";
        for (int i = ListBox2.Items.Count - 1; i >= 0; i--)
        {                
              string mt = ListBox2.Items[i].ToString();
              sql = sql + " or MotherTongue = '" + mt + "'";              
        }
        sql = sql + ")"
    }
