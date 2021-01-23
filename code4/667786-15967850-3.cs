    public byte[] GetSerializedMessages()
    {
        try {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                // skipped: serialize etc
                return memoryStream.ToArray();
            }
        } catch(Exception ex) {
            Logger.Log("Failed to serialize. Reason: " + ex.Message);
            throw; // it doesn't stop being a problem just because we logged it
        }
    }
