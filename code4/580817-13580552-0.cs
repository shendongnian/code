    public void RemoveTemporaryFiles() {
            string pathTemp = "d:\\uploads\\";
            if ((pathTemp.Length > 0) && (Directory.Exists(pathTemp))) {
                foreach (string file in Directory.GetFiles(pathTemp)) {
                    try {
                        FileInfo fi = new FileInfo(file);
                        if (fi.CreationTime < DateTime.Now.AddHours(-24)) {
                            File.Delete(file);
                        }
                    } catch (Exception) { }
                }
            }
        }
