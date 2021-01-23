        // We don't want any leading or trailing whitespace, so we remove it here.
        public override string English
        {
            get { return base.English; }
            set { base.English = value.Trim(); }
        }
