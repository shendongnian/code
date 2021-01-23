            string addedControlId;
            if (!column.ColumnName.Equals("ZVID"))
            {
                tb = new TextBox();
                tb.Id= column.ColumnName;
                cell.Controls.Add(tb);
                addedControlId = tb.Id;
            }
            else
            {
                DropDownList dd = new DropDownList();
                dd.ID = column.ColumnName;
                dd.DataSource = zorgData;
                dd.DataValueField = "ZVID";
                dd.DataTextField = "Naam";
                dd.DataBind();
                cell.Controls.Add(dd);
                addedControlId = dd.Id;
            }
            RequiredFieldValidator val = new RequiredFieldValidator{
                ControlToValidate = addedControlId,
                ErrorMessage = "Shame on you, you did not fill this value"
            }
            cell.Controls.Add(val);
            
            
