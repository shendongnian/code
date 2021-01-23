    using System.Collections.Generic;
    
    public struct Factory < KeyType, GeneralProduct > 
    {
        //Register a object with the factory
        public void> Register< SpecificProduct >(KeyType key)
            where SpecificProduct : GeneralProduct, new()
        {
            if( m_mapProducts == null )
                    {
                m_mapProducts = new SortedList< KeyType, CreateFunctor >(); 
            }
            CreateFunctor createFunctor = Creator<SpecificProduct>; 
            m_mapProducts.Add(key, createFunctor);
        }
    
        //Create a registered object 
        public GeneralProduct Create( KeyType key )
        {
            CreateFunctor createFunctor = m_mapProducts[ key ];
            return createFunctor(); 
        }
        
        private GeneralProduct Creator < SpecificProduct >() 
            where SpecificProduct : GeneralProduct, new()
        {
            return new SpecificProduct();
        }
    
        private delegate GeneralProduct CreateFunctor(); 
    
        private SortedList<KeyType, CreateFunctor>  m_mapProducts;
    }
