    using (NetworkStream stream = m_Stream)
    {
        object o;
        while (Serializer.NonGeneric.TryDeserializeWithLengthPrefix(
            stream, PrefixStyle.Base128,
            Utilities.CommunicationHelper.resolver, out o))
        {
            if (o != null)
            {
                //TODO: Do something with the incoming protobuf object
                // clear o, just to give GC the very best chance while we sleep
                o = null;
            }
            Thread.Sleep(1); // <=== not sure why you want to sleep here, btw
        }
    }
