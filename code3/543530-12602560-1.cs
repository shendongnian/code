        public Tag Select(Predicate<Tag> predicate)
        {
                Tag tag = new Tag();
                bool result = predicate(tag);
                return tag;
        }
