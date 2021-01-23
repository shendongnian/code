    static object staticSyncObject = new object();  // in class level fields
    // ... 
    foreach( string savePath in paths )
    {
        byte[] bytes = report.Render("PDF", deviceInfo);
        lock(staticSyncObject) // synchronized() was java, ideally would time out
        {
            using(FileStream fs = new FileStream(@savePath+".pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
