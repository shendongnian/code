		protected override void Dispose(bool disposing)
		{
			// CryptoStream.Dispose(bool) has a bug in read mode. If the reader doesn't read all the way to the end of the stream, it throws an exception while trying to
			// read the final block during Dispose(). We'll work around this here by moving to the end of the stream for them. This avoids the thrown exception and
			// allows everything to be cleaned up (disposed, wiped from memory, etc.) properly.
			if ((disposing) &&
				(CanRead) &&
				(m_TransformMode == CryptoStreamMode.Read))
			{
				const int BUFFER_SIZE = 32768;
				byte[] buffer = new byte[BUFFER_SIZE];
				while (Read(buffer, 0, BUFFER_SIZE) == BUFFER_SIZE)
				{
				}
			}
			base.Dispose(disposing);
            ...
