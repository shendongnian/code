    Use below mentioned code.
    
    EntityCommand cmd = conn.CreateCommand();
                cmd.CommandText = "CMSEntities.sproc_Forums_GetForums";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
                using (EntityDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    List<Forum> forums = new List<Forum>();
                    while (reader.Read())
                    {
                        Forum forum = new Forum(
                            1,
                            "",
                            DateTime.Now,
                            reader["Title"].ToString(),
                            reader["Description"].ToString(),
                            0,
                            false,
                            null,
                            null,
                            null,
                            true,
                            reader["ForumGroup"].ToString(),
                            (int)reader["ThreadCount"],
                            null,
                            DateTime.Now,
                            null);
                        forums.Add(forum);
                    }
                    return forums;
                }
            }
        }
    }
    
    Hope it helps.
