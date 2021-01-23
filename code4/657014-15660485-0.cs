        private class GenericDataRow : IEquatable<GenericDataRow>
        {
            public string Name { get; set; }
            public bool Equals(GenericDataRow other)
            {
                return Name.Equals(other.Name);
            }
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as GenericDataRow);
            }
        }
