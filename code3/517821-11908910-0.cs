        [Test]
        public void Test()
        {
            string user = @"Domain\UserName";
            var files = Directory.EnumerateFiles(@"C:\TestFolder")
                .Where(x => IsOwner(x, user));
            Parallel.ForEach(files, File.Delete);
        }
        private static bool IsOwner(string filepath, string user)
        {
            return string.Equals(File.GetAccessControl(filepath).GetOwner(typeof (NTAccount)).Value, user,
                                 StringComparison.OrdinalIgnoreCase);
        }
