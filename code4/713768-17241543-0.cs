    string sql = "SELECT * FROM payments ";
    string field = "";
    string value = "";
    int parameter_count = 0;
    foreach(HtmlTableRow row in table.Rows)
    { 
        foreach(Control c in row.Cells[1].Controls)
        {
            if (c is Textbox)
            {
                 TextBox txt = c as TextBox;
                 if (txt.Text.Length > 0)
                 {
                     field = txt.ID;
                     value = txt.Text.Trim();
                     if (parameter_count == 0)
                     {
                         sql += string.Format(" WHERE {0}='{1}' ", field, value);
                         parameter_count++;
                     }
                     else
                     {
                         sql += string.Format(" AND {0}='{1}' ", field, value);
                         parameter_count++;
                     }
                 }
            }
            else if (c is DropDownList)
            {
                DropDownList ddl = c as DropDownList;
                 if (ddl.SelectedValue.Length > 0)
                 {
                     field = ddl.ID;
                     value = ddl.SelectedValue.Trim();
                     if (parameter_count == 0)
                     {
                         sql += string.Format(" WHERE {0}='{1}' ", field, value);
                         parameter_count++;
                     }
                     else
                     {
                         sql += string.Format(" AND {0}='{1}' ", field, value);
                         parameter_count++;
                      }
                  }
              }
          }
      }
