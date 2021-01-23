            public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ProjectContract))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            var item = (ProjectContract)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            return item.Id == this.Id && item.ProjectId == this.ProjectId;
        }
        int? _requestedHashCode;
        public override int GetHashCode()
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = (this.Id.ToString() + this.ProjectId.ToString()).GetHashCode();
            return _requestedHashCode.Value;
        }
