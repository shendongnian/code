        /// <summary>
        /// Creates an exact duplicate of the entity provided
        /// </summary>
        /// <param name="source">The source copy of the entity</param>
        /// <returns>An exact duplicate entity</returns>
        public TEntity Clone(TEntity Source)
        {
            // Don’t serialize a null object, simply return the default for that object
            if (ReferenceEquals(Source, null))
            {
                return default(TEntity);
            }
            var dcs = new DataContractSerializer(typeof (TEntity));
            using (Stream stream = new MemoryStream())
            {
                dcs.WriteObject(stream, Source);
                stream.Seek(0, SeekOrigin.Begin);
                return (TEntity) dcs.ReadObject(stream);
            }
        }
