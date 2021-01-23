    if (pbspic.Image == null)
            {
                cmd.Parameters.Add("@Photo", SqlDbType.VarChar).Value = "NULL";
            }
            else
            {
                cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = GetPic(pbspic.Image);
            }
            dm2.ExecActQuery("StudentsInsert", cmd);
