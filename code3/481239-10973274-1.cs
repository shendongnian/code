    public void UploadFile(string path) {
    	WebClient wc = new WebClient();
    	wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    	Int64 numBytes = new FileInfo(path).Length;
    	FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
    	BinaryReader br = new BinaryReader(fs);
    	Byte[] data = br.ReadBytes(Convert.ToInt32(numBytes));
    	br.Close();
    	fs.Close();
    	wc.UploadData("http://127.0.0.1/upload.php", "POST", data);
    }
