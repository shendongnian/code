           for (int k = 0; k < listPost.Count; k++)
            {
                string post_id1 = listPost[k].PostId;
                for (int j = 0; j < listComment.Count; j++)
                {
                    comId = listComment[j].CommentId;
                    comments1 = listComment[j].Comments;
                    commentTime = listComment[j].CommentTimeStamp;
                    DbConnection.Open();
                    DbCommand = new OleDbCommand("select count(response_id) from       mw_response where response_id = '" + comId + "'", DbConnection);
                    OleDbDataReader DbReader = DbCommand.ExecuteReader();
                    while (DbReader.Read())
                    {
                        count = DbReader[0].ToString();
                        cnt = Convert.ToInt32(count);
                        if ((cnt == 0) && (memComments != ""))
                        {
                            DbCommand = new OleDbCommand("insert into mw_response(post_id,response,response_id, resp_date,community) values('" + post_id1 + "','" + comments1 + "','" + comId + "','" + commentTime + "','LinkedIn')", DbConnection);
                            DbCommand.ExecuteNonQuery();
                            //update productid and customerid
                            DbCommand = new OleDbCommand("update mw_response set prod_id = (select prod_id from mw_post where post_id='" + post_id1 + "'),customer_id = (select customer_id from mw_customer where customer_id = '" + id + "') where response_id = '" + comId + "'", DbConnection);
                            DbCommand.ExecuteNonQuery();
                                                        }
                    }
                    DbReader.Close();
                    DbConnection.Close();
                }
            }
