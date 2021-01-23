    /// <summary>
    /// Serializes the given object to byte stream
    /// </summary>
    public sealed class Serializer {
        /// <summary>
        /// Serializes the given object to byte stream
        /// </summary>
        /// <param name="objectToSeralize">Object to be serialized</param>
        /// <returns>byte array of searialize object</returns>
        public static byte[] Serialize(object objectToSeralize) {
            byte[] objectBytes;
            using (MemoryStream stream = new MemoryStream()) {
                //Creating binary formatter to serialize object.
                BinaryFormatter formatter = new BinaryFormatter();
                //Serializing objectToSeralize. 
                formatter.Serialize(stream, objectToSeralize);
                objectBytes = stream.ToArray();
            }
            return objectBytes;
        }
        /// <summary>
        /// De-Serialize the byte array to object
        /// </summary>
        /// <param name="arrayToDeSerialize">Byte array of Serialize object</param>
        /// <returns>De-Serialize object</returns>
        public static object DeSerialize(byte[] arrayToDeSerialize) {
            object serializedObject;
            using (MemoryStream stream = new MemoryStream(arrayToDeSerialize)) {
                //Creating binary formatter to De-Serialize string.
                BinaryFormatter formatter = new BinaryFormatter();
                //De-Serializing.
                serializedObject = formatter.Deserialize(stream);
            }
            return serializedObject;
        }
    }
