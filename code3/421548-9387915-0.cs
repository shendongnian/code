    Response.Write(style);
    Response.Write("Pretty Excel Export File\r");
    Response.Write("Generated on " + DateTime.Now.ToShortDateString() + "\r\r");
    Response.Write(swriter.ToString());
    Response.End();
