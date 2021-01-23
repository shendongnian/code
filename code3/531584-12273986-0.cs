    string xml = @"<CONFIGURATION> 
    <Files> 
    	<File>D:\Test\TestFolder\TestFolder1\TestFile.txt</File> 
    	<File>D:\Test\TestFolder\TestFolder1\TestFile01.txt</File> 
    	<File>D:\Test\TestFolder\TestFolder1\TestFile02.txt</File> 
    	<File>D:\Test\TestFolder\TestFolder1\TestFile03.txt</File> 
    	<File>D:\Test\TestFolder\TestFolder1\TestFile04.txt</File> 
    </Files> 
    <SizeMB>3</SizeMB> 
    <BackupLocation>D:\Log backups\File backups</BackupLocation> 
    </CONFIGURATION>";
    
    var xdoc = XDocument.Parse(xml);
    var configuration = xdoc.Element("CONFIGURATION");
    string sizeMB = configuration.Element("SizeMB").Value;
    string backupLocation = configuration.Element("BackupLocation").Value;
    string[] files = configuration.Element("Files").Elements("File").Select(c => c.Value).ToArray();
    
    Console.WriteLine(sizeMB);
    Console.WriteLine(backupLocation);	  
    Console.WriteLine(string.Join("\r\n", files));
