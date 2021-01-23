        public void SomeFunction()
        {
            Document document = SelectDocument("xlsx");
            document.DoStuff(); //Open file, excel operation then save file.
            document = SelectDocument("docx");
            document.DoStuff(); //Open file, word operation then save file.
        }
        public Document SelectDocument(string fileExtension)
        {
            switch (fileExtension)
            {
                case "docx": return new Word();
                case "xlsx": return new Excel();
                default: return null;
            }
        }
