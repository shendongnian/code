            protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            var blobUri = "http://127.0.0.1:10000/devstoreaccount1/abc/test2.vhd?sr=b&st=2012-08-17T10%3A29%3A46Z&se=2012-08-17T11%3A29%3A46Z&sp=r&sig=dn7cnFhP1xAPIq0gH6klc4nifqgk7jfOgb0hV5Koi4g%3D";
            CloudBlockBlob blockBlob = new CloudBlockBlob(blobUri);
            var blobSize = 200 * 1024 * 1024;
            int blockSize = 1024 * 1024;
            Response.Clear();
            Response.ContentType = "APPLICATION/OCTET-STREAM";
            System.String disHeader = "Attachment; Filename=\"" + blockBlob.Name + "\"";
            Response.AppendHeader("Content-Disposition", disHeader);
            for (long offset = 0; offset < blobSize; offset += blockSize)
            {
                using (var blobStream = blockBlob.OpenRead())
                {
                    if ((offset + blockSize) > blobSize)
                        blockSize = (int)(blobSize - offset);
                    byte[] buffer = new byte[blockSize];
                    blobStream.Read(buffer, 0, buffer.Length);
                    Response.BinaryWrite(buffer);
                    Response.Flush();
                }
            }
            Response.End();
        }
