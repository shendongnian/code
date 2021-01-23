                using (var sw = new StreamWriter(Path.Combine(outputFiles, outfilename)))
                {
                    // we modified the first line, so lets write it
                    sw.WriteLine(line);
                    // now we just rewrite all remaining lines
                    while ((line = sr.ReadLine()) != null)
                        sw.WriteLine(line);
                    // and write to disk
                    sw.Flush();
                }
            }
        });
