    > for (int i = 0; i < chkItems.Items.Count; i++)
        {
            if (chkItems.Items[i].Selected == true)
            {
               ListItem li =new ListItem();
               li.Text = chkItems.Items[i].Text;  
               li.Value = chkItems.Items[i].Value;  
               chkItems.Items.Remove(li);
            }
        }
