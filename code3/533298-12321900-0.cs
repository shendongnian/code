    public class FileData{
    	public int id;
    	public string fname;
    }
    void Main()
    {
    	List<FileData> list = new List<FileData>{
    		new FileData { id=1, fname="C:\\install.res.1042.dll"},
    		new FileData { id=2, fname="C:\\install.res.1041.dll" },
    		new FileData { id=3, fname="C:\\install.res.9999.dll"}
    	};
    	
    	string[] FolderFiles = System.IO.Directory.GetFiles("C:\\");
    	
    	var results = list
    		.Where(fd => 
    			FolderFiles.Any(x=>Path.GetFileNameWithoutExtension(x) ==             
    			Path.GetFileNameWithoutExtension(fd.fname)));
    			
    	Console.WriteLine(results);
    }
