        private string MakePath(string subFolder, object obj, int index)
        {        
            //tempFileName here is created beased on the TYPE of the object passed
            string tempFileName = obj.GetType().Name;
            return MakePath(subFolder,tempFileName , index); 
    
        }
    
        private string MakePath(string subFolder, string tempFileName, int index)
        {
            //combine directory path
            string dir = System.IO.Path.Combine(_outputDir, subFolder);
      
            //compute final file name based on the several 
            //parameters and tempFileName parameter
            string fileName = string.Format("{0} {1} {2}.xml",
                tempFileName, _dateTimeSource.Now.ToString(DATE_FORMAT), index.ToString());
            return System.IO.Path.Combine(dir, fileName);
        }
