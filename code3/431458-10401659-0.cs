            var dbPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dropbox\\host.db");
            string[] lines = System.IO.File.ReadAllLines(dbPath);
            byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
            string folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
            Console.WriteLine(folderPath);
