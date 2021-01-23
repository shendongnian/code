     SqlConnection conn = new SqlConnection(" your connection string ");
     conn.Open();
     SqlDataAdapter da = new SqlDataAdapter("select * from ddltable ", conn);
     DataSet ds = new DataSet();
     da.Fill(ds, " ddltable ");
     DropDownList1.DataSource = ds.Tables["ddltable "].DefaultView ;
     DropDownList1.DataTextField = "id";
     DropDownList1.DataBind(); 
