        public static bool TryGetArray(ref SomeObject[] source )
        {
            try
            {
                var localSource = new List<SomeObject>{new SomeObject(), new SomeObject()};
               
                var temp = new SomeObject[localSource.Count + source.Length];
                Array.Copy(source, temp, source.Length);
                Array.ConstrainedCopy(localSource.ToArray(), 0, temp, source.Length, localSource.Count);
                source = temp;
            }
            catch
            {
                return false;
            }
            return true;
        }
