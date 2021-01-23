    class LotsaProps1
    {
        /* Prop1 is mapped to array index 0 */
        [ArrayToPropertyMap( ArrayIndex = 0 )]
        public string Prop1
        {
            get;
            set;
        }
        /* Prop2 is mapped to array index 2 */
        [ArrayToPropertyMap( ArrayIndex = 2 )]
        public string Prop2
        {
            get;
            set;
        }
        /* Prop3 is not mapped */
        public string Prop3
        {
            get;
            set;
        }
        /* Prop4 is mapped to array index 1 */
        [ArrayToPropertyMap( ArrayIndex = 1 )]
        public string Prop4
        {
            get;
            set;
        }
    }
