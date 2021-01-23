    var appDataPath = Environment.GetFolderPath(
                                       Environment.SpecialFolder.ApplicationData);
    var dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
    var lines = System.IO.File.ReadAllLines(dbPath);
    var dbBase64Text = Convert.FromBase64String(lines[1]);
    var folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
    Console.WriteLine(folderPath);
