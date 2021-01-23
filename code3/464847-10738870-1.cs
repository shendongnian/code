    [Serializable]
    [DataContract]
    public class KeyValue<K,V>
    {
        /// <summary>
        /// The Key
        /// </summary>
        [DataMember]
        public K Key { get; set; }
        /// <summary>
        /// The Value
        /// </summary>
        [DataMember]
        public V Value { get; set; }
    }
