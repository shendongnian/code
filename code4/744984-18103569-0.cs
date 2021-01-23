        string queryparam = '';
          for (int i=0; i<checkboxlist1.Items.Count; i++) {
             if (checkboxlist1.Items[i].Selected)
                {  queryparam  += (queryparam.Length = 0) ? "id = " + checkboxlist1.Items[i].Text : " or id = "  checkboxlist1.Items[i].Text }
          }
