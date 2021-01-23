    protected void Button18_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string output = "Output";
        sb.Append(output);
        sb.Append("\r\n");
        
        string text = sb.ToString();
        
        Response.Clear();
        Response.ClearHeaders();
        Response.AppendHeader("Content-Length", text.Length.ToString());
        Response.ContentType = "text/plain";
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"output.txt\"");
    
        Response.Write(text);
        Response.End();
    }
