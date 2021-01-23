    private string GetResxNameByValue(string value)
        {
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager("YourNamespace.YourResxFileName", this.GetType().Assembly);
            var entry=
                rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Value.ToString() ==value);
            var key = entry.Key.ToString();
            return key;
        }
