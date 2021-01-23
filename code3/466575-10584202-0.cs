    Assembly clrAssembly = ...;
    const string createTemplate = @"CREATE ASSEMBLY [{0}] AUTHORIZATION [dbo] FROM 0x{1};";
    var bytes = new StringBuilder();
    using (var dll = File.OpenRead(clrAssembly.Location))
    {
	int @byte;
	while ((@byte = dll.ReadByte()) >= 0)
		bytes.AppendFormat("{0:X2}", @byte);
    }
    var sql = string.Format(createTemplate, clrAssembly.GetName().Name, bytes);
