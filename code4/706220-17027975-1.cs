    class FileProcessorFactory {
        public FileProcessor getFileProcessor(string extension){
            switch (extension){
                case ".pdf":
                    return new PdfFileProcessor();
                case ".xls":
                    return new ExcelFileProcessor();
            }
        }
    }
    class IFileProcessor{
        public Object processFile(Stream inputFile);
    }
    
    class PdfFileProcessor : IFileProcessor {
        public Object processFile(Stream inputFile){
            // do things with your inputFile
        }
    }
    class ExcelFileProcessor : IFileProcessor {
        public Object processFile(Stream inputFile){
            // do things with your inputFile
        }
    }
