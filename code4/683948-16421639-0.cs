           System.Data.DataView dv = (System.Data.DataView)sqlds.Select(DataSourceSelectArguments.Empty);
            if (dv.Count > 0)
            {
                DropDownList1.DataSource = sqlds;
                DropDownList1.DataTextField = "yourfield";
                DropDownList1.DataBind();
            }
