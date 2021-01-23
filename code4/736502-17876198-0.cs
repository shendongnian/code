      protected void DataList_ItemDataBound(Object sender,DataListEventArgs e)
         {
               if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==   ListItemType.AlternatingItem)
     {
         ucTextBox myTextControl=(ucTextBox)e.Item.FindControl("ucTextBox1");
         if (myTextControl!= null)
          {
         TextBox txtCaseCD=(TextBox)myTextControl.Find("txtCaseCD");
          //now you can use txtCaseCD without a null reference error
           
          }
         
     }
     }
