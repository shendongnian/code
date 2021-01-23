    Response.Clear();
    Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
    Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.pptx;", getLegalFileName(CurrentPresentation.Presentation_NM)));
    Response.Flush();                
    Response.BinaryWrite(masterPresentation.ToArray());
    Response.End();
