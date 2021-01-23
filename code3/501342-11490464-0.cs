    public object GetKye(KyeType type)
    {
        switch (type)
        {
            case KyeType.String:
                return this.kye;
            case KyeType.Int32:
                return Int32.Parse(this.kye);
            case KyeType.Bool:
                return this.kye.ToLower().Equals("true");
        }
        return null;
    }
