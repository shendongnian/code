    Assembly assembly = Assembly.GetExecutingAssembly();
    string ns = typeof(Program).Namespace;
    string name = String.Format("{0}.MyDocuments.Document.pdf", ns);
    using (var stream = assembly.GetManifestResourceStream(name))
    {
    	if (stream == null) return null;
    	byte[] buffer = new byte[stream.Length];
    	stream.Read(buffer, 0, buffer.Length);
    	return buffer;
    }
