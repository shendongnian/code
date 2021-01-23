        SqlCommand updateArticle = new SqlCommand("UPDATE gameTB SET homeodds = @homeodds, awayodds = @awayodds, drawodds = @drawodds Where mround = @mround AND mid=@mid");
        DAL.ExecuteNonQuery(updateArticle);
        if (@@rowcount = 0) Then
        SqlCommand saveArticle = new SqlCommand("Insert Into gameTB(mround, mtime, mid, mname, homeodds, awayodds, drawodds) VALUES (@mround,@mtime,@mid,@mname,@homeodds,@awayodds,@drawodds)");
        saveArticle.Parameters.Add("@mround", SqlDbType.Int).Value = mround;
        saveArticle.Parameters.Add("@mtime", SqlDbType.DateTime).Value = mtime;
        saveArticle.Parameters.Add("@mid", SqlDbType.Int).Value = mid;
        saveArticle.Parameters.Add("@mname", SqlDbType.VarChar, 255).Value = mname;
        saveArticle.Parameters.Add("@homeodds", SqlDbType.Float).Value = homeodds;
        saveArticle.Parameters.Add("@awayodds", SqlDbType.Float).Value = awayodds;
        saveArticle.Parameters.Add("@drawodds", SqlDbType.Float).Value = drawodds;
        DAL.ExecuteNonQuery(saveArticle);
        EndIf;
