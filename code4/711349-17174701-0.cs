        protected void Button2_Click(object sender, EventArgs e)
        {
            try{
                elem.Value = "test 2 test 2 test 2";
                doc.Save(Server.MapPath("xml/test.xml"));
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
         }
