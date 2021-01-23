      protected void Button1_Click(object sender, EventArgs e)
        {
            ArticleTitle = Request.Form["ArticleTitle"].ToString();
                ArticleDate = Request.Form["ArticleDate"].ToString();
                ArticleAuthor = Request.Form["ArticleAuthor"].ToString();
                ArticleBody = Request.Form["ArticleBody"].ToString();
    
    
                string dpath = Server.MapPath(@"App_Data") + "/MySite.mdb";
                string connectionstring = @"Data source='" + dpath + "';Provider='Microsoft.Jet.OLEDB.4.0';";
                OleDbConnection con = new OleDbConnection(connectionstring);
                string QuaryString = string.Format("insert into tblArticles(ArticleTitle, PostDate) values ('{0}','{1}','{2}','{3}')", ArticleTitle, ArticleBody, ArticleAuthor, ArticleDate);
                OleDbCommand cmd = new OleDbCommand(QuaryString, con);
                con.Open();
                cmd.ExecuteNonQuery();
        }
