        private void calcResults()
        {
           MakePath(id, results.GetType(), _resultCount);
           MakePath(id, "XYZ", _resultSICount)
        }
        private string MakePath(string subFolder, Type type, int index)
        {
            return MakePath(subFolder, type.Name, index);
        }
        private string MakePath(string subFolder, string tempFileName, int index)
        {
            string dir = System.IO.Path.Combine(_outputDir, subFolder);
            string fileName = string.Format("{0} {1} {2}.xml",
                   tempFileName, _dateTimeSource.Now.ToString(DATE_FORMAT), index.ToString());
            return System.IO.Path.Combine(dir, fileName);
        }
