        Byte[] empImage = null;
        empImage = ShowEmpImage(empno);
        context.Response.Buffer = true;
        context.Response.Clear();
        context.Response.ContentType = "image/jpeg";
        context.Response.Expires = 0;
        context.Response.AddHeader("Content-Disposition", "attachment;filename=yourimagename.jpg");
        context.Response.AddHeader("Content-Length", empImage.Length.ToString());
        context.Response.BinaryWrite(empImage);
