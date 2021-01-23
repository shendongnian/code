                byte[] stub = GetStubExecutable(); //read in your new stub file
                output.Write(stub, 0, stub.Length);
                
                using (ZipFile zip = new ZipFile())
                {
                    String[] filenames = System.IO.Directory.GetFiles(Path.Combine(path,FilesFolder)); 
                     // Add the rest of they files you'd like in your SFX
                    foreach (String filename in filenames)
                    {
                        ZipEntry e = zip.AddFile(filename, OutputZipFolder);
                    }
                   
                    zip.Save(output); // save the zip to the outputstream
                }
