        public byte[] callbackData { get; set; }
        /// <summary>
        /// Delegate to call back
        /// </summary>
        [NotMapped]
        public Callback callback
        {
            get
            {
                if (_callback == null && callbackData != null && callbackData.Count() > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (var stream = new MemoryStream(callbackData))
                    {
                        _callback = formatter.Deserialize(stream) as Callback;
                    }
                }
                return _callback;
            }
            set
            {
                _callback = value;
                if (value == null)
                {
                    callbackData = null;
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (var stream = new MemoryStream())
                    {
                        formatter.Serialize(stream, value);
                        callbackData = stream.ToArray();
                    }
                }
            }
        }
