    Response.Write(style);
    Response.Write("Pretty Excel Export File\n");
    Response.Write("Generated on " + DateTime.Now.ToShortDateString() + "\n\n");
    Response.Write(swriter.ToString());
    Response.End();
