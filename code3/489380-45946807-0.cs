    dotnet add package Microsoft.Extensions.FileProviders.Embedded
    using Microsoft.Extensions.FileProviders;
    var fp = new EmbeddedFileProvider(typeof(Program).Assembly);
    // get all resources as an enumerable
    foreach (var fileInfo in fp.GetDirectoryContents(""))
        Console.WriteLine($"Name: {fileInfo.Name}, Length: {fileInfo.Length}, ...");
    // get a specific one by name
    var stream = fp.GetFileInfo("Resources.TextFile.txt").CreateReadStream();
