    partial class MyClass
    {
        public Channel this[int channel]
        {
            get
            {
                return this.GetChannelObject(channel);
            }
            /*
             * You probably don't want consumers to be able to change the underlying
             * object, so I've commented this out. You could also use a private
             * setter instead if you want to internally make use of the indexing
             * semantic, but since you're most likely just wrapping an IList<Channel>
             * anyway, you probably don't need it.
             *
             * set
             * {
             *     this.SetChannelObject(channel);
             * }
             */
        }
    }
