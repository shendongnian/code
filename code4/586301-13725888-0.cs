        [SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
			if (info == null)
				throw new ArgumentNullException("info");
			
            info.AddValue("name of compiler generated field", _bla);
        }
