       public void MergeAttribute(string key, string value, bool replaceExisting)
        {
          ...
          if (!replaceExisting && this.Attributes.ContainsKey(key))
            return;
          this.Attributes[key] = value;
        }
