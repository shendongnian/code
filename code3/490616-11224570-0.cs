     protected void Button1_Click(object sender, EventArgs e)
            {
                string attachment = "attachment; filename=Call-Details-Report-" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt";
                Response.ContentType = "text/html";
                Response.AddHeader("Content-Disposition", attachment); 
                Response.AddHeader("Pragma", "public");
    
                Response.WriteFile(@"C:\test.txt");
                Response.SetCookie(new HttpCookie("DStatus", "Completed")); 
    
                Response.End();
            }
