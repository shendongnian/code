    using System.Windows.Media;// for WPF
    // for WindowsForms using System.Drawing
    using System;
    using System.Collections.Generic;
    public class ColorHeatMap
    {
    	public ColorHeatMap()
    	{
    		initColorsBlocks();
    	}
    	public ColorHeatMap(byte alpha)
    	{
    		this.Alpha = alpha;
    		initColorsBlocks();
    	}
    	private void initColorsBlocks()
    	{
    		ColorsOfMap.AddRange(new Color[]{
    					Color.FromArgb(Alpha, 0, 0, 0) ,//Black
    					Color.FromArgb(Alpha, 0, 0, 0xFF) ,//Blue
    					Color.FromArgb(Alpha, 0, 0xFF, 0xFF) ,//Cyan
    					Color.FromArgb(Alpha, 0, 0xFF, 0) ,//Green
    					Color.FromArgb(Alpha, 0xFF, 0xFF, 0) ,//Yellow
    					Color.FromArgb(Alpha, 0xFF, 0, 0) ,//Red
    					Color.FromArgb(Alpha, 0xFF, 0xFF, 0xFF) // White
    				});
    	}
    	public Color GetColorForValue(double val, double maxVal, byte Alpha)
    	{
    		double valPerc = val / maxVal;// value%
    		double colorPerc = 1d / ColorsOfMap.Count;// % of each block of color
    		double blocOfColor = valPerc / colorPerc;// the integer part repersents how many block to skip
    		int blockIdx = (int)blocOfColor;// Idx of 
    		double valPercResidua = valPerc - blockIdx * colorPerc;//remove the integer part
    		double percOfColor = valPercResidua / colorPerc;
    		var cTarget = ColorsOfMap[blockIdx];
    
    		Color cNext = ColorsOfMap[ColorsOfMap.Count - 1];//last color
    		if (blockIdx < ColorsOfMap.Count - 1)
    			cNext = ColorsOfMap[blockIdx + 1];
    
    		var deltaR = Math.Abs(cTarget.R - cNext.R);
    		var deltaG = Math.Abs(cTarget.G - cNext.G);
    		var deltaB = Math.Abs(cTarget.B - cNext.B);
    		
    		var R = cTarget.R + (deltaR * percOfColor);
    		var G = cTarget.G + (deltaG * percOfColor);
    		var B = cTarget.B + (deltaB * percOfColor);
    		Color c = Color.FromArgb(Alpha, (byte)R, (byte)G, (byte)B);     //DD 19/06/2016 19:29:36	
    		return c;
    	}
    	public byte Alpha = 0xff;
    	public List<Color> ColorsOfMap= new List<Color>();
    }
