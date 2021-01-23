    for(int i = 0; i < cmb.Items.Count; i++)
    {
        for(int y = 0; y < cmb.Items.Count; y++)
        {
             if( y != i && cmb.Items[i].Text == cmb.Items[y].Text)
             {
                  cmb.Items.RemoveAt(i);
                  break;
             }
        }
    }
