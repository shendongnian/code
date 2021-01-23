    internal static string GetFromResources(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(res => res.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));
            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream == null) return string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
