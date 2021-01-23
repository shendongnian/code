    // This is the delegate. Any instance with DeletedEventHandler type 
    // can point a method which returns voids and accepts parameters (object,bool)
    public delegate void DeletedEventHandler(object sender, bool deleted);
    public class FileDeleter
    {   
         private DeletedEventHandler onDelete;
         public event DeletedEventHandler OnDelete
         {
             // The add and remove accessors
             add { onDelete += value; }
             remove { onDelete -= value; }
         }
         public void Delete(string filePath)
         {
             try
             {
                 File.Delete(filePath);
                 RaiseOnDelete(true);
             }
             catch
             {
                 RaiseOnDelete(false);
             }
         }
         private void RaiseOnDelete(bool deleted) 
         {
             if (onDelete != null)
                 onDelete(this, deleted); // all methods added executes here
         }
    }
    public void TestMethod()
    {
        FileDeleter deleter = new FileDeleter();
        // Note that both ShowDeleteInfoWindows and ShowDeleteInfoConsole are in form of void(object,bool) which is compatible with DeletedEventHandler 
        deleter.OnDelete += new DeletedEventHandler(DeletedOnConsole);
        deleter.OnDelete += new DeletedEventHandler(ShowDeleteInfoWindows);
        deleter.Delete(@"C:\test.txt");
    }
    
    private void ShowDeleteInfoConsole(object deleter, bool isDeleted)
    {
        Console.WriteLine(isDeleted);
    }
    private void ShowDeleteInfoWindows(object deleter, bool isDeleted)
    {
        MessageBox.Show(isDeleted.ToString());
    }
