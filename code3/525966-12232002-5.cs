    /// <summary>
    /// Defines an angle in Radians
    /// </summary>
    public struct Radians
    {
    	public static readonly Radians ZERO_PI = 0;
    	public static readonly Radians ONE_PI = System.Math.PI;
    	public static readonly Radians TWO_PI = ONE_PI * 2;
    	public static readonly Radians HALF_PI = ONE_PI * 0.5;
    	public static readonly Radians QUARTER_PI = ONE_PI * 0.25;
    	
    	#region Public Members
    
    	/// <summary>
    	/// Angle value
    	/// </summary>
    	public double Value;
    	/// <summary>
    	/// Finds the Cosine of the angle
    	/// </summary>
    	public double Cos
    	{
    		get
    		{
    			return System.Math.Cos(this);
    		}
    	}
    	/// <summary>
    	/// Finds the Sine of the angle
    	/// </summary>
    	public double Sin
    	{
    		get
    		{
    			return System.Math.Sin(this);
    		}
    	}
    
    	#endregion
    
    	/// <summary>
    	/// Constructor
    	/// </summary>
    	/// <param name="value">angle value in radians</param>
    	public Radians(double value)
    	{
    		this.Value = value;
    	}
    	/// <summary>
    	/// Gets the angle in degrees
    	/// </summary>
    	/// <returns>Returns the angle in degrees</returns>
    	public Degrees GetDegrees()
    	{
    		return this;
    	}
    
    	public Radians Reduce()
    	{
    		double radian = this.Value;
    		bool IsNegative = radian < 0;
    		radian = System.Math.Abs(radian);
    		while (radian >= System.Math.PI * 2)
    		{
    			radian -= System.Math.PI * 2;
    		}
    		if (IsNegative && radian != 0)
    		{
    			radian = System.Math.PI * 2 - radian;
    		}
    		return radian;
    	}
    
    	#region operator overloading
    
    	/// <summary>
    	/// Conversion of Degrees to Radians
    	/// </summary>
    	/// <param name="deg"></param>
    	/// <returns></returns>
    	public static implicit operator Radians(Degrees deg)
    	{
    		return new Radians(deg.Value * System.Math.PI / 180);
    	}
    	/// <summary>
    	/// Conversion of integer to Radians
    	/// </summary>
    	/// <param name="i"></param>
    	/// <returns></returns>
    	public static implicit operator Radians(int i)
    	{
    		return new Radians((double)i);
    	}
    	/// <summary>
    	/// Conversion of float to Radians
    	/// </summary>
    	/// <param name="f"></param>
    	/// <returns></returns>
    	public static implicit operator Radians(float f)
    	{
    		return new Radians((double)f);
    	}
    	/// <summary>
    	/// Conversion of double to Radians
    	/// </summary>
    	/// <param name="dbl"></param>
    	/// <returns></returns>
    	public static implicit operator Radians(double dbl)
    	{
    		return new Radians(dbl);
    	}
    	/// <summary>
    	/// Conversion of Radians to double
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <returns></returns>
    	public static implicit operator double(Radians rad)
    	{
    		return rad.Value;
    	}
    	/// <summary>
    	/// Add Radians and a double
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <param name="dbl"></param>
    	/// <returns></returns>
    	public static Radians operator +(Radians rad, double dbl)
    	{
    		return new Radians(rad.Value + dbl);
    	}
    	/// <summary>
    	/// Add Radians to Radians
    	/// </summary>
    	/// <param name="rad1"></param>
    	/// <param name="rad2"></param>
    	/// <returns></returns>
    	public static Radians operator +(Radians rad1, Radians rad2)
    	{
    		return new Radians(rad1.Value + rad2.Value);
    	}
    	/// <summary>
    	/// Add Radians and Degrees
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <param name="deg"></param>
    	/// <returns></returns>
    	public static Radians operator +(Radians rad, Degrees deg)
    	{
    		return new Radians(rad.Value + deg.GetRadians().Value);
    	}
    	/// <summary>
    	/// Sets Radians value negative
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <returns></returns>
    	public static Radians operator -(Radians rad)
    	{
    		return new Radians(-rad.Value);
    	}
    	/// <summary>
    	/// Subtracts a double from Radians
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <param name="dbl"></param>
    	/// <returns></returns>
    	public static Radians operator -(Radians rad, double dbl)
    	{
    		return new Radians(rad.Value - dbl);
    	}
    	/// <summary>
    	/// Subtracts Radians from Radians
    	/// </summary>
    	/// <param name="rad1"></param>
    	/// <param name="rad2"></param>
    	/// <returns></returns>
    	public static Radians operator -(Radians rad1, Radians rad2)
    	{
    		return new Radians(rad1.Value - rad2.Value);
    	}
    	/// <summary>
    	/// Subtracts Degrees from Radians
    	/// </summary>
    	/// <param name="rad"></param>
    	/// <param name="deg"></param>
    	/// <returns></returns>
    	public static Radians operator -(Radians rad, Degrees deg)
    	{
    		return new Radians(rad.Value - deg.GetRadians().Value);
    	}
    
    
    	#endregion
    
    	public override string ToString()
    	{
    		return String.Format("{0}", this.Value);
    	}
    
    	public static Radians Convert(object value)
    	{
    		if (value is Radians)
    			return (Radians)value;
    		if (value is Degrees)
    			return (Degrees)value;
    
    		return System.Convert.ToDouble(value);
    	}
    }
