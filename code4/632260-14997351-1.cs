        public override bool Equals(object obj)
        {
            if (obj is SnpCodeModel)
                return ((SnpCodeModel)obj).SnpCode == this.SnpCode
            return false;
        }
