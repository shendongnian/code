            byte[] buffer = new byte[1];
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.AddHeader("Content-Disposition", "attachment;filename=blank.txt");
            Response.End();
