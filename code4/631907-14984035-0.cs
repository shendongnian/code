            var filteredData = new List<string>();
            if (Session["Contract"] != null)
            {
                filteredData = Session["Contract"].ToString().Split(',').Join(
                                    data, 
                                   i => i.ToString().Trim().ToUpper(), 
                                   x => x.Term.Trim().ToUpper(),
                                   (i, x) => x);
            }
            LV_Jobs.DataSource = filteredData;
            LV_Jobs.DataBind();
