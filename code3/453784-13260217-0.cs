    using System;
    
    namespace Stackoverflow
    {
    	static public class NumericExtensions
    	{
    		static public decimal SafeDivision(this decimal Numerator, decimal Denominator)
    		{
    			return (Denominator == 0) ? 0 : Numerator / Denominator;
    		}
    	}
    
    }
