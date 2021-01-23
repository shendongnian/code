    interface Hasher {
        void Reinitialize();
        void AddByte(byte b);
        byte[] Result { get; }
    }
