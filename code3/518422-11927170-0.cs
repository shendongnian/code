        public static string[] FindAllFiles(string rootDir) {
            var pathsToSearch = new Queue<string>();
            var foundFiles = new List<string>();
            pathsToSearch.Enqueue(rootDir);
            while (pathsToSearch.Count > 0) {
                var dir = pathsToSearch.Dequeue();
                try {
                    var files = Directory.GetFiles(dir);
                    foreach (var file in Directory.GetFiles(dir)) {
                        foundFiles.Add(file);
                    }
                    foreach (var subDir in Directory.GetDirectories(dir)) {
                        pathsToSearch.Enqueue(subDir);
                    }
                } catch (Exception /* TODO: catch correct exception */) {
                    // Swallow.  Gulp!
                }
            }
            return foundFiles.ToArray();
        }
       
