        static Dictionary<string, Workbook> _openedWorkBooks = new Dictionary<string, Workbook>();    
        public static Workbook GetWorkbook(string filePath)  {    
            Workbook wkb = null;    
            if (!(_openedWorkBooks.TryGetValue(filePath, out wkb)))    
            {
                // Open the file and store it into the dictionary    
            }
            return wkb;  
        }
        // remember to remove it when it's closed  
        public static CloseWorkbook()  
        {    // need to remove the corresponding key from the dictionary  
        }
