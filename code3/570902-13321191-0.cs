        private static readonly string CACHE =  @"MyWordCache";
        static void PutFile(object wordDoc, string fname)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists(CACHE))
                    store.CreateDirectory(CACHE);
                object fullname = Path.Combine(CACHE, fname);
                wordDoc.SaveAs(ref fullname, ...);
            }
        }
        protected bool Downloadfile(string fname)
        { 
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists(CACHE))
                    return false;
                var fullname = Path.Combine(CACHE, fname);
                using (var fileStream = store.OpenFile(fullname, FileMode.Open))
                {
                    int fileSize = (int)fileStream.Length;
                    byte[] Buffer = new byte[fileSize];
                    fileStream.Read(Buffer, 0, fileSize);
                    Response.ContentType = ContType(fullname);
                    Response.BinaryWrite(Buffer);
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + "form" + ".doc");
                    Response.End();
                }
            }
            return true;
        }
 
