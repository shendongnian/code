    class LotsaProps1
    {
        [ArrayToPropertyMap( ArrayName = "Array1", ArrayIndex = 0 )]
        [ArrayToPropertyMap( ArrayName = "Array2", ArrayIndex = 3 )]
        public string Prop1
        {
            get;
            set;
        }
        [ArrayToPropertyMap( ArrayName = "Array1", ArrayIndex = 2 )]
        [ArrayToPropertyMap( ArrayName = "Array2", ArrayIndex = 2 )]
        public string Prop2
        {
            get;
            set;
        }
        /* Notice that Prop3 is not mapped to Array1 */
        [ArrayToPropertyMap( ArrayName = "Array2", ArrayIndex = 1 )]
        public string Prop3
        {
            get;
            set;
        }
        [ArrayToPropertyMap( ArrayName = "Array1", ArrayIndex = 1 )]
        [ArrayToPropertyMap( ArrayName = "Array2", ArrayIndex = 0 )]
        public string Prop4
        {
            get;
            set;
        }
    }
