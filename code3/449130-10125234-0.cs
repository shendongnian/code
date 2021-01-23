                DataTable paths = BusinessLogic.Article.Path_List();
                for (int i = 0; i < paths.Rows.Count; i++)
                {
                    if (String.Compare(Request.Url.AbsolutePath.ToString(), paths.Rows[i]["ART_Path"].ToString(), true) == 0)
                    {
                        BusinessLogic.ArticleTypes aType = (BusinessLogic.ArticleTypes)Convert.ToInt32(paths.Rows[i]["ART_Type"]);
                        Context.RewritePath("/article.aspx?type=" + aType.ToString() + "&id=" + paths.Rows[i]["ART_ID"].ToString());
                        break;
                    }
                }
