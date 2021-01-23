    ArticleContent = ds1.Tables[0].Rows[i]["ArticleContent"].ToString();
    if (ArticleContent.Length > 260)
    {
        if (ArticleContent.Substring(250).Contains("."))
        {
            ArticleContent = ArticleContent.Remove(ArticleContent.IndexOf('.', 250)) + "...";
        }
        else
        {
            ArticleContent = ArticleContent.Remove(ArticleContent.Substring(0, 250)) + "...";
        }
    }
