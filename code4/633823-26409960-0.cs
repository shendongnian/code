			    var resources = new ResourceManager(type);
			    using (var set = resources.GetResourceSet(CultureInfo.InvariantCulture, true, false))
			    {
			        if (set != null)
			        {
			            foreach (DictionaryEntry res in set)
			            {
			                var key = res.Key as string;
			                var val = res.Value as string;
			                if (key == null || val == null)
			                    continue;
			                if (!key.EndsWith(".Text"))
			                    continue;
			                key = key.Substring(0, key.Length - ".Text".Length);
			                // key is now the name of your control
			                // val is the string the designer stored as its Text in the default resource
			            }
			        }
			    }
