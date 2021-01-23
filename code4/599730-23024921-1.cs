    string sql = "select Lsn_File from Lessons_tbl where Lsn_name = '"TextBox1.Text + "'";
               
            cmd = new SqlCommand(sql, dal.cn());
                
            dal.Open();
            SqlDataReader dr = cmd.ExecuteReader();
             dr.Read();
             if (dr.HasRows)
               {             
                  byte[] lesson = (byte[])(dr[0]);
                  spathfile = System.IO.Path.GetTempFileName();
                  //move from soures to destination the extension until now is .temp
                 System.IO.File.Move(spathfile, 
                  System.IO.Path.ChangeExtension(spathfile,".pdf"));
                    //make it real pdf file  extension .pdf
                  spathfile = System.IO.Path.ChangeExtension(spathfile, ".pdf");
                   System.IO.File.WriteAllBytes(spathfile, lesson );
                   this.axAcroPDF1.LoadFile(spathfile);
             dal.close();
