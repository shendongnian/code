    protected void btnDownload_Click(object sender, EventArgs e)
    {
        // No error so write as attachment
        Response.ContentType = "text/csv";
        Response.AddHeader("content-disposition", "attachment;filename=data.csv");
        // Write your output here
        Response.Write(...);
        Response.End();
    }
