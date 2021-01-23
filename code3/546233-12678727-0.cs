    public static Vector4 operator +(Vector4 p1, Vector4 p2)
    {
    	p1.X += p2.X;
    	p1.Y += p2.Y;
    	p1.Z += p2.Z;
    	p1.W += p2.W;
    	return p1;
    }
    
    public static Vector4 operator -(Vector4 p1, Vector4 p2)
    {
    	p1.X -= p2.X;
    	p1.Y -= p2.Y;
    	p1.Z -= p2.Z;
    	p1.W -= p2.W;
    	return p1;
    }
