    // Serialize the object. Write each field to the SerializationWriter
    // then add this to the SerializationInfo parameter
    public void GetObjectData (SerializationInfo info, StreamingContext ctxt) {
        SerializationWriter sw = SerializationWriter.GetWriter ();
        sw.Write (id1);
        sw.Write (id2);
        sw.Write (id3);
        sw.Write (s1);
        sw.Write (s2); 
        // more properties here         
        sw.AddToInfo (info);
    }
