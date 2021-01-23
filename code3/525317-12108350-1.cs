    protected void Button1_Click(object sender, EventArgs e)
        {
    
            File.Copy(Server.MapPath("") + "\\abc.aspx", (Server.MapPath("") + "\\" + TextBox1.Text + ".aspx"));
            File.Copy(Server.MapPath("") + "\\abc.aspx.cs", (Server.MapPath("") + "\\" + TextBox1.Text + ".aspx.cs"));
            
            //.aspx Page
    
            StreamReader sr = new StreamReader(Server.MapPath("") + "\\" + TextBox1.Text + ".aspx");
            string fileContent = sr.ReadToEnd();
            sr.Close();
            using (StreamWriter Sw = new StreamWriter(Server.MapPath("") + "\\" + TextBox1.Text + ".aspx"))
            {
                fileContent = fileContent.Replace("abc",  TextBox1.Text);
                Sw.WriteLine(fileContent);
                Sw.Flush();
                Sw.Close();
            }
    
            //.aspx.cs Page
    
            StreamReader sr1 = new StreamReader(Server.MapPath("") + "\\" + TextBox1.Text + ".aspx.cs");
            string fileContent1 = sr1.ReadToEnd();
            sr1.Close();
            using (StreamWriter Sw1 = new StreamWriter(Server.MapPath("") + "\\" + TextBox1.Text + ".aspx.cs"))
            {
                fileContent1 = fileContent1.Replace("abc", TextBox1.Text);
                Sw1.WriteLine(fileContent1);
                Sw1.Flush();
                Sw1.Close();
            }
           
        }
