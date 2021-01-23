    public ActionResult GetFile(int id) {
        var f = FileAcc.GetInfo(id);
    		int bufferSize = 1024, bps = 1024;
    		using (FileStream sourceStream = new FileStream(Server.MapPath(f.file_url), FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize)) {
    		    using (Born2Code.Net.ThrottledStream destinationStream = new Born2Code.Net.ThrottledStream(Response.OutputStream, bps)) {
    		        byte[] buffer = new byte[bufferSize];
    		        int readCount = sourceStream.Read(buffer, 0, bufferSize);
    		        Response.Buffer = false;
    		        while (readCount > 0) {
    		            destinationStream.Write(buffer, 0, readCount);
    		            readCount = sourceStream.Read(buffer, 0, bufferSize);
    		        }
    		    }
    		}
        return new EmptyResult();
    }
