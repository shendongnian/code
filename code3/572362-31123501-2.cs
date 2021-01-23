        public override string Publisher
        {
            get
            {
                foreach (Tag tag in tags)
                {
                    if (tag == null)
                        continue;
                    string value = tag.Publisher;
                    if (value != null)
                        return value;
                }
                return null;
            }
            set
            {
                foreach (Tag tag in tags)
                    if (tag != null)
                        tag.Publisher = value;
            }
        }
