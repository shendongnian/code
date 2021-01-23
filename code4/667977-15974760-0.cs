        public int Drop(IDataObject pDataObj, int grfKeyState, Point pt, ref DropEffect pdwEffect)
        {
            try
            {
                var dataObj = new DataObject(pDataObj);
                if (dataObj.ContainsFileDropList())
                {
                    StringCollection files = dataObj.GetFileDropList();
                    // Do something with files...
                    
                }
                return 0;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(string.Format("Error: {0}", ex));
                return 1;
            }
        }
