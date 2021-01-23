            foreach (ZipEntry entry in zip)
            {
                CrcCalculatorStream reader = entry.OpenReader();
                MemoryStream memstream = new MemoryStream();
                reader.CopyTo(memstream);
                byte[] bytes = memstream.ToArray();
                System.IO.Stream stream = new System.IO.MemoryStream(bytes); 
            }
        }
    }
