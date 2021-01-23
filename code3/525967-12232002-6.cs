    	public double Value;       
    
    	public Degrees(double value) { this.Value = value; }
    
    	public Radians GetRadians()
    	{
    		return this;
    	}
    
    	public Degrees Reduce()
    	{
    		return this.GetRadians().Reduce();
    	}
    
    	public double Cos
    	{
    		get
    		{
    			return System.Math.Cos(this.GetRadians());
    		}
    	}
    
    	public double Sin
    	{
    		get
    		{
    			return System.Math.Sin(this.GetRadians());
    		}
    	}
    
    	#region operator overloading
    
    	public static implicit operator Degrees(Radians rad)
    	{
    		return new Degrees(rad.Value * 180 / System.Math.PI);
    	}
    
    	public static implicit operator Degrees(int i)
    	{
    		return new Degrees((double)i);
    	}
    
    	public static implicit operator Degrees(float f)
    	{
    		return new Degrees((double)f);
    	}
    
    	public static implicit operator Degrees(double d)
    	{
    		return new Degrees(d);
    	}
    
    	public static implicit operator double(Degrees deg)
    	{
    		return deg.Value;
    	}
    
    	public static Degrees operator +(Degrees deg, int i)
    	{
    		return new Degrees(deg.Value + i);
    	}
    
    	public static Degrees operator +(Degrees deg, double dbl)
    	{
    		return new Degrees(deg.Value + dbl);
    	}
    
    	public static Degrees operator +(Degrees deg1, Degrees deg2)
    	{
    		return new Degrees(deg1.Value + deg2.Value);
    	}
    
    	public static Degrees operator +(Degrees deg, Radians rad)
    	{
    		return new Degrees(deg.Value + rad.GetDegrees().Value);
    	}
    
    	public static Degrees operator -(Degrees deg)
    	{
    		return new Degrees(-deg.Value);
    	}
    
    	public static Degrees operator -(Degrees deg, int i)
    	{
    		return new Degrees(deg.Value - i);
    	}
    
    	public static Degrees operator -(Degrees deg, double dbl)
    	{
    		return new Degrees(deg.Value - dbl);
    	}
    
    	public static Degrees operator -(Degrees deg1, Degrees deg2)
    	{
    		return new Degrees(deg1.Value - deg2.Value);
    	}
    
    	public static Degrees operator -(Degrees deg, Radians rad)
    	{
    		return new Degrees(deg.Value - rad.GetDegrees().Value);
    	}
    
    	#endregion
    
    	public override string ToString()
    	{
    		return String.Format("{0}", this.Value);
    	}
    
    	public static Degrees Convert(object value)
    	{
    		if (value is Degrees)
    			return (Degrees)value;
    		if (value is Radians)
    			return (Radians)value;
    
    		return System.Convert.ToDouble(value);
    	}
    }
