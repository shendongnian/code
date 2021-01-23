    protected void Button18_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string output = "Output";
        sb.Append(output);
        sb.Append("\r\n");
        
        string text = sb.ToString();
        
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Length", text.Length.ToString());
        Response.ContentType = "text/plain";
        Response.AppendHeader("content-disposition", "attachment;filename=\"output.txt\"");
    
        Response.Write(text);
        Response.End();
    }
