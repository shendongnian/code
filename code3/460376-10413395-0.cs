            DataTable dt = new DataTable();
              string select_qry = "SELECT questionTitle, Answer1, Answer2, Answer3, Answer4, Answer5  FROM tblQuestions WHERE CourseCode = \'" + question + "\'";
              SqlCommand cmd = new SqlCommand(select_qry);
              dt= GetData(cmd);
              if (dt.Rows.Count > 0)
              {
                  LabelRadio1.Questions = dt.Rows[0]["questionTitle"].ToString();
                  LabelRadio1.Answers = dt.Rows[0]["Answer1"].ToString();
                  LabelRadio1.Answers = dt.Rows[0]["Answer2"].ToString();
                  LabelRadio1.Answers = dt.Rows[0]["Answer3"].ToString();
                  LabelRadio1.Answers = dt.Rows[0]["Answer4"].ToString();
                  LabelRadio1.Answers = dt.Rows[0]["Answer5"].ToString(); 
              }
         
        }
        public DataTable GetData(SqlCommand cmd)
        {
            string sqlCon =System.Configuration.ConfigurationManager.ConnectionStrings["OnlineExamDBCS"].ToString();
            SqlConnection Con = new SqlConnection(sqlCon);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Con;
            Con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        } 
