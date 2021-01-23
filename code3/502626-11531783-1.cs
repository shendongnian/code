    class Program
    {
        static void Main(string[] args)
        {
            var db = @"Data Source=D:\Temp\sisotest.sdf".CreateSqlCe4Db();
            db.EnsureNewDatabase();
    
            var info = new FileInfo2(@"D:\Temp\test.txt");
            db.UseOnceTo().InsertAs<FileData>(info);
        }
    }
    
    public class FileInfo2
    {
        public FileInfo2(string cConfigSys)
        {
            var f = new FileInfo(cConfigSys);
            DirectoryName = f.DirectoryName;
            Length = f.Length;
            Name = f.Name;
        }
    
        public string DirectoryName { get; private set; }
        public long Length { get; private set; }
        public string Name { get; private set; }
    }
    
    public class FileData
    {
        public Guid Id { get; set; }
        public string DirectoryName { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
    }
