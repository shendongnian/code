      public static void CopyToZip(string inArchive, string outArchive)
      {
          using (inZip = new ZipFile(inArchive),
                 outZip = new ZipFile(outArchive))
          {
              Func<String,Func<String,Stream>> getInStreamReturner = (name) => {
                  return new Func<String,Stream>(a){ return inZip[a].OpenReader(); };
              };
              foreach (ZipEntry entry in inZip)
              {
                  if (!entry.IsDirectory)
                  {
                      string zipEntryName = entry.FileName;
                      outZip.AddEntry(zipEntryName,
                                      getInStreamReturner(zipEntryName),
                                      (name, stream) => stream.Close() );
                  }
              }
              outZip.Save();
          }
      }
