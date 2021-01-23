    protected void Button18_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "text/plain";
        Response.AppendHeader("content-disposition", "attachment;filename=output.txt");
        StringBuilder sb = new StringBuilder();
        string output = "Output";
        sb.Append(output);
        sb.Append("\r\n");
        
        Response.Write(sb.ToString());
        Response.End();
    }
