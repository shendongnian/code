            using (MemoryStream ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                using (CsvWriter csv = new CsvWriter(tw))
                {
                    csv.WriteRecords(errors); // Converts error records to CSV
                    tw.Flush(); // flush the buffered text to stream
                    ms.Seek(0, SeekOrigin.Begin); // reset stream position
                    Attachment a = new Attachment(ms, "errors.csv"); // Create attachment from the stream
                    // I sent an email here with the csv attached.
                }
            }
