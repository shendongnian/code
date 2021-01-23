    //Declare a new table and add it as child of tdparent
            Table table1 = new Table();
            table1.ID = "tablename";
            table1.Style.Add(HtmlTextWriterStyle.Width, "auto");
            tdparent.Controls.Add(table1);
            //Decalre a new table row and add it as child of tableskills
            TableRow tr1 = new TableRow();
            tr1.ID = "tr1Skills";
            table1.Controls.Add(tr1);
            CompanyBAL objBAL = new CompanyBAL();
            int id;
            if (ddlFunctional.SelectedValue == "All")
            {
                id = -99;
            }
            else
            {
                id = Convert.ToInt32(ddlFunctional.SelectedValue.ToString());
            }
            DataSet ds = objBAL.GetSkillSets(id);
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                TableCell td = new TableCell();
                td.ID = "td" + ds.Tables[1].Rows[i]["skilltype"].ToString();
                td.Style.Add(HtmlTextWriterStyle.VerticalAlign, "top");
                td.Style.Add(HtmlTextWriterStyle.Width, "auto");
                
                tr1.Controls.Add(td);
                // add CheckBoxList to tabelCell
                CheckBoxList cbl = new CheckBoxList();
                cbl.ID = "cbl" + ds.Tables[1].Rows[i]["skilltype"].ToString();
                cbl.Style.Add(HtmlTextWriterStyle.Width, "auto");
                td.Controls.Add(cbl);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TableCell tbCell = ((TableCell)tr1.FindControl("td" + ds.Tables[0].Rows[i]["skilltype"].ToString()));
                CheckBoxList cb= ((CheckBoxList)tbCell.FindControl("cbl" + ds.Tables[0].Rows[i]["skilltype"].ToString()));
                
                cb.Items.Add(new ListItem(ds.Tables[0].Rows[i]["skillname"].ToString(), ds.Tables[0].Rows[i]["skillname"].ToString()));
            }
