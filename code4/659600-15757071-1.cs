      protected void attributes()
      {
       SqlConnection con = new 
    
    SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd = new SqlCommand("select attributesequenceNumber as attsno,ProductCode as pcode, P26 as '" + 26 + "',P28 as '" + 28 + "',P30 as '" + 30 + "',P32 as '" + 32 + "',P34 as '" + 34 + "',P36 as '" + 36 + "',P38 as '" + 38 + "',P40 as '" + 40 + "',P42 as '" + 42 + "',SHXS as XS,SHS as S,SHM as M,SHL as L,SHXL as XL,SHXXL as XXL from tblattribute where ProductCode='" + Session["ImgProdCode"] + "'", con);
        //SqlCommand cmd = new SqlCommand("select Col.value('local-name(.)', 'varchar(Max)') as ColName from (select * from tblattribute where ProductCode ='"+Session["ImgProdCode"]+"' for xml path(''), type) as T(XMLCol) cross apply T.XMLCol.nodes('*') as n(Col) where Col.value('.', 'varchar(1)') = 1 " , con);
    try
    {
      con.Open();
      cmd.ExecuteNonQuery();
      DataTable dtble = new DataTable();
      SqlDataAdapter dap = new SqlDataAdapter(cmd);
      dap.Fill(dtble);
      if (dtble.Rows.Count > 0)
      {
        result = dtble.Columns.Cast<DataColumn>()
     .Where(c => c.ColumnName != "pcode" && c.ColumnName != "attsno")
     .Where(c => dtble.Rows[0][c].ToString() == "1")
     .Select(c => c.ColumnName)
     .ToList();
        res = result.Count;
        lbl = new Button[res];
        for (i = 0; i < result.Count; i++)
        {
    
          lbl[i] = new Button();
          lbl[i].Text = result[i];
          lbl[i].ID = "btn" + i.ToString();
          lbl[i].Width = 30;
          //lbl[i].Click += new EventHandler(lbl_click);
          lbl[i].CssClass = "label";
          div1.Controls.Add(lbl[i]);
        }
    
      }
    
    }
    catch
    {
      throw;
    }
        finally
        {
          if (con != null)
          {
            con.Close();
          }
        }
      } 
   
      [WebMethod]
      public static string lbl_click()
      {
        return "label1";
      }
