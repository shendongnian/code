    public class Stream : INotifyPropertyChanged
    {
        private SubCodec _codec;
        internal SubCodec Codec
        {
            get
            {
                return _codec;
            }
            set
            {
                _codec = value;
                //note that you'll have problems if this code is set to other parents, 
                //or is removed from this object and then modified
                _codec.Parent = this;
            }
        }
        internal class SubCodec
        {
            internal Stream Parent { get; set; }
    
            private string _audioCodec;
            public string VideoCodec
            {
                get { return _audioCodec; }
                set
                {
                    _audioCodec = value;
                    Parent.OnPropertyChanged("VideoCodec");
                }
            }
        }
    }
