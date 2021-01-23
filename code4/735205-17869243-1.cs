    public class ClientCode
    {
        public async void WriteFile()
        {
            var fileReadWrite = new FileReadWrite("DataCodeWords.txt");
            await fileReadWrite.WriteDataCords(42);
        }
        public async void ReadFile()
        {
            var fileReadWrite = GetFileReadWriteForFile("DataCodeWords.txt"); //Method for retreiving correct instance of FileWriteRead class
            await fileReadWrite.ReadDataCords();
        }
        private FileReadWrite GetFileReadWriteForFile(string fileName)
        {
        }
    }
