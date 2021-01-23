        public override bool Equals(object obj)
        {
            var isEqual = false;
            var otherSet = obj as Set;
            if (otherSet != null)
            {
                isEqual = _set.Count == otherSet.Count;
                isEqual &= _set.SequenceEqual(otherSet);
            }
            return isEqual;
        }
