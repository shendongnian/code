    public void MergeAttribute(string key, string value, bool replaceExisting)
    {
        if (!string.IsNullOrEmpty(key))
        {
            if (replaceExisting || !this.Attributes.ContainsKey(key))
            {
                this.Attributes[key] = value;
            }
            return;
        }
        else
        {
            throw new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, "key");
        }
    }
