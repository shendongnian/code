        public boolean OnSave(object entity,
                              object id,
                              object[] state,
                              string[] propertyNames,
                              IType[] types)
        {
      
                for ( int i=0; i<propertyNames.Length; i++ )
                {
                    if ( objectHasAttributeOnproperty(propertyNames[i], Truncate))
                    {
                        trucate(entity, propertyNames[i])
                        return true;
                    }
                }
           
            return true;
        }
