    string appDataPath = Environment.GetFolderPath(
                                       Environment.SpecialFolder.ApplicationData);
    string dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
    string[] lines = System.IO.File.ReadAllLines(dbPath);
    byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
    string folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
    Console.WriteLine(folderPath);
