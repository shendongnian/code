    Response.Clear();
    Response.ContentType = "application/CSV";
    Response.AddHeader("content-disposition", "attachment; filename=\"" + filename + ".csv\"");
    Response.Write(csvBuilder.ToString());
    Response.End();
