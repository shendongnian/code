        using (CabFile file = new CabFile(HttpContext.Current.Request.Files[0].InputStream))
        {
            file.EntryExtract += CabEntryExtract;
            file.ExtractEntries();
        }
        static void CabEntryExtract(object sender, CabEntryExtractEventArgs e)
        {
            // e.Entry.Name contains the entry name
            // e.Entry.Data contains a byte[] with the entry data
            // e.Entry.LastWriteTime contains the entry last write time
            // e.Entry.Size contains the entry uncompressed size
        }
