	string rootPath = @"path you your root folder";
	var header = "***********************************" + Environment.NewLine;
	var files = Directory.GetFiles(rootPath, "*.cs", SearchOption.AllDirectories);
	
	var result = files.Select(path => new { Name = Path.GetFileName(path), Contents = File.ReadAllText(path)})
		              .Select(info =>   
                          header
		                + "Filename: " + info.Name + Environment.NewLine
						+ header
						+ info.Contents);
		
    
    var singleStr = string.Join(Environment.NewLine, result);
	Console.WriteLine ( singleStr );
	File.WriteAllText(@"C:\output.txt", singleStr, Encoding.UTF8);
