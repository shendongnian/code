     if (ddlProvince.SelectedIndex != -1)
                {
                    query = query + " and PROVINCE_CODE=" + ddlProvince.SelectedValue;
                }
    
                if (ddlCity.SelectedIndex != -1)
                {
                    query = query + " and CITY_CODE=" + ddlProvince.SelectedValue;
                }
    
                if (ddlSpec.SelectedIndex != -1)
                {
                    query = query + " and SPECIALIZATION=" + ddlProvince.SelectedValue;
                }
                
                
                string tQuery = "Select * from Doc";
                if (query.Length > 0)
                {
                    query = query.Remove(0, 4);
                    tQuery = tQuery + query;
                }
                // Exeucate -- tQuery
