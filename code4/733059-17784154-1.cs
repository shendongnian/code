        public int GetObjectIDByProperty(Array Objects, int property)
        {
            foreach(T_One myT_One in Objects)
            { 
                //Check Type with 'is'
                if (myT_One is T_Two))
                {
                    //Now cast:
                    T_Two myT_Two = (T_Two)myT_One;    
 
                    if (myT_Two.Property == property)
                        return myT_Two.ID;
                }
            }
            return -1; //Object with this property didn't exist
        }
