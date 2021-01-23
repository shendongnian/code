     public int InsertArticle(ArticleItem articleitem)
        {
            SqlParameter articleid = new SqlParameter(Parameters.ArticleID, SqlDbType.Int);
            articleid.Direction = ParameterDirection.Output;
    
            SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, INSERT_ARTICLE,
                                      new SqlParameter(Parameters.Body, articleitem.Body),
                                      new SqlParameter(Parameters.Category, articleitem.Category),
                                      new SqlParameter(Parameters.ExpireDate, articleitem.ExpireDate),
                                      new SqlParameter(Parameters.PublishDate, articleitem.PublishDate),
                                      new SqlParameter(Parameters.Published, articleitem.Published),
                                      new SqlParameter(Parameters.Section, articleitem.Section),
                                      new SqlParameter(Parameters.Title, articleitem.Title),
                                      articleid);
            return (int)articleid.Value;
        }
