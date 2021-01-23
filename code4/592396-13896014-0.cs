            var output = new MemoryStream();
            using (var zip = new ZipFile())
            {
                foreach (var file in files)
                {
                    var ms = new MemoryStream(file.Value);
                    ms.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry(file.Key, ms);
                   
                }
                zip.Save(output);
            }
            return output;
