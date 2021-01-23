                using (var fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                using (var sr = new StreamReader(fs))
                {
                    var str = sr.ReadToEnd();
                    // ...
                    using (var sw = new StreamWriter(fs))
                    {
                        // ...
                    }
                }
            }
