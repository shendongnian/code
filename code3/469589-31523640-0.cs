    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
    Response.AppendHeader("Content-Disposition", "attachment;filename=HelloWorld.docx");
    mem.Position = 0;
    byte[] arr = mem.ToArray();
    Response.BinaryWrite(arr);
    Response.Flush();
    Response.End();
