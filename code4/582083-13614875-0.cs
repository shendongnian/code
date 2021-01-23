        public IUsePhone Owner { get; private set; }
        public Phone(T owner)
        {
            this.Owner = owner;
        }
        public int GetOwnerID()
        {
            return this.Owner.GetOwnerID();
        }
