                    Stream getStreams = rptDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                    byte[] getbytes = GetStreamAsByteArray(getStreams);
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Length", getbytes.Length.ToString());
                    Response.BinaryWrite(getbytes);
