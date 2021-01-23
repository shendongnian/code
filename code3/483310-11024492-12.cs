        private static Vector Add(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new VectorTypeException("Vector Dimensions Must Be Equal");
            }
            else
            {
                //perform generic matrix addition/operation
                double[] newValues = new double[v1.Length];
                for (int i = 0; i < v1.Length; i++)
                {
                    newValues[i] = v1.Values[i] + v2.Values[i];
                }
    
                //or use some factory/service to give you a Vector2D, Vector3D, or VectorND
                switch (newValues.Length)
                {
                	case 1 :
                		return new Vector1D() { Values = newValues };
                	case 2 :
                		return new Vector2D() { Values = newValues };
                	case 3 :
                		return new Vector3D() { Values = newValues };
                	case 4 :
                		return new Vector4D() { Values = newValues };
                	//... and so on
                	default :
                		throw new DimensionOutOfRangeException("Do not support vectors greater than 10 dimensions");
                		//or you could just return the generic Vector which doesn't expose X,Y,Z values?
                }
            }
        }
