     string fileOut = ((Request.QueryString["msisdn"] )+ (Request.QueryString["shortcode"]) + (Request.QueryString["password"]).ToString());
    string mydocpath = 
        	Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        StringBuilder sb = new StringBuilder();
        foreach (string txtName in Directory.EnumerateFiles(mydocpath,"outputreport.txt")) 
        {
            using (StreamReader sr = new StreamReader(txtName))
            {
                sb.AppendLine(fileOut);
                sb.AppendLine("= = = = = =");
                sb.Append(sr.ReadToEnd());
                sb.AppendLine();
                sb.AppendLine();
            }
        }
        using (StreamWriter outfile = 
        	new StreamWriter(mydocpath + @"\outputreport.txt"))
        {
            outfile.Write(sb.ToString());
        }
