            protected void Page_Load(object sender, EventArgs e)
            {
                var byteArray = File.ReadAllBytes("test.pdf");
    
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
                Response.BinaryWrite(byteArray);
                Response.Flush();
    
                Response.End();
            }
