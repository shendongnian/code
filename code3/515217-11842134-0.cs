    // zip XElement xdoc and add to requests MTOM value
    using (MemoryStream ms = new System.IO.MemoryStream())
    {   
       xdoc.Save(ms);  
       ms.Position = 0;
     
       // create the ZipEntry archive from the xml doc store in memory stream ms
       using (MemoryStream outputMS = new System.IO.MemoryStream())
       {
          using (ZipOutputStream zipOutput = new ZipOutputStream(outputMS))
          {
              ZipEntry ze = new ZipEntry("example.xml");
              zipOutput.PutNextEntry(ze);
              zipOutput.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
              zipOutput.Finish();
              zipOutput.Close();
     
              // add the zip archive to the request
              SubmissionReceiptListAttachmentMTOM = new base64Binary();
              SubmissionReceiptListAttachmentMTOM.Value = outputMS.ToArray();
          }
     
          outputMS.Close();
       }
     
       ms.Close();
    }
