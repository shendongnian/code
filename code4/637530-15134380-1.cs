        private void calcMD5(String[] filePathes)  //Array contains a path of all files
        {
            Dictionary<String, String> hashToFilePathes = new Dictionary<String, String>();
            foreach (string file_name in filePathes)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(file_name))
                    {
                        //This will get you dictionary where key is md5hash and value is filepath
                        hashToFilePathes.Add(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower(), file_name);
                    }
                }
            }
            // Here will be all duplicates
            List<String> listOfDuplicates = hashToFilePathes.GroupBy(e => e.Key).Where(e => e.Count() > 1).SelectMany(e=>e).Select(e => e.Value).ToList();
        }
    } 
