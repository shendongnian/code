    public class ARRAY : ANY_DERIVED
        {
            public Type de; // ARRAY type
            public int size;
            public int initIndex;
            public int finalIndex;
    
        public ARRAY(int initIndex, int finalIndex)
        {   
            this.initIndex = initIndex;
            this.finalIndex = finalIndex;
            size = finalIndex - initIndex + 1;
        }
    
        public void NewDim(int initIndex, int finalIndex)
        {
            if (de == null)
                de = new ARRAY(initIndex, finalIndex);
            else
                ((ARRAY)de).NewDim(initIndex, finalIndex);
        }
    
        public void SetBaseType(Type t)
        {
            if (de == null)
                de = t;
            else
                ((ARRAY)de).SetBaseType(t);
        }
       }
