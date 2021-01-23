    class Car 
    {
        [ShouldSerialize]
        public int PropX {get;set}
        // This property won't be serialized because it is internal
        public int PropY { get; set; }
    }
