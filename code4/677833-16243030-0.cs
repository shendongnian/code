        [ContractAnnotation("d:null => false")]
        static public bool IsValid(double? d)
        {
            return d != null && IsValid(d.Value);
        }
