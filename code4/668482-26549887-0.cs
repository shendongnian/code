        public static string RarFiles(string rarPackagePath,
            Collection<string> accFiles)
        {
            string error = "";
            try
            {
                StringBuilder fileListBuilder = new StringBuilder();
                foreach (var fList_item in accFiles)
                {
                    fileListBuilder.Append("\"" + fList_item + "\" ");
                }
                string fileList = fileListBuilder.ToString();
               ... (no change from this point on)
        }
                
