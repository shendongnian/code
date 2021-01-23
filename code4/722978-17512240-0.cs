	public static void ResourceToFile(string fileName, string dir, byte[] resource) {
		Directory.CreateDirectory(dir);
		string path = Path.Combine(dir, fileName);
		File.WriteAllBytes(path, resource);
	}
