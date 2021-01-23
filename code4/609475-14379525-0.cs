        int i = 0;
        while (dr.Read())
        {
            if (i != 0)
            {
                Response.Write(",<br>");
            }
            Response.Write("insert into test values(N'" + dr[0] + "', N'" + dr[1] + "')");
            i++;
        }
