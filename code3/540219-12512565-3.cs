    public class FileItem
    {
       public FileItem()
       {
           this.OpenFileCommand 
               = new SimpleCommand(()=> Process.StartNew(this.FullName));
       }
       public string NodeName { get; set; }
       public string FullName { get; set; }
       public string Extension { get; set; }
       public ICommand OpenFileCommand { get; set;}
    }
