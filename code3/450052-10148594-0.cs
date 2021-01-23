    using System;
    using System.Runtime.InteropServices;
    
    #if WIN64
    using FT_Pos = System.Int32;
    #else
    using FT_Pos = System.IntPtr;
    #endif
    
    namespace SharpFont.Internal
    {
    	/// <summary>
    	/// Internally represents a BBox.
    	/// </summary>
    	/// <remarks>
    	/// Refer to <see cref="BBox"/> for FreeType documentation.
    	/// </remarks>
    	[StructLayout(LayoutKind.Sequential)]
    	internal struct BBoxRec
    	{
    		internal FT_Pos xMin, yMin;
    		internal FT_Pos xMax, yMax;
    	}
    }
