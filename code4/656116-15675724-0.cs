            if (directory.SubDirectory != null || directory.SubDirectory.Count != 0)
            {
                foreach (var item in directory.SubDirectory.Select(s => new DirectoryExt(s)).ToList())
                {
                    this.SubDirectory.Add(item);
                }
            }
