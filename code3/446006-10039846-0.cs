        public override bool Equals(object obj)
        {
            if (obj is IQuestion)
                return this.Response == ((IQuestion)obj).Response;
            else
                return base.Equals(obj);
        }
