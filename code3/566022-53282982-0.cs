        public static Guid GenerateSeededGuid<T>(T value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value.GetHashCode()).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
