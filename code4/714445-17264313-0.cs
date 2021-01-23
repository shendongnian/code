    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
    
    
    	ResizeableControl rc;
    
    	private void Form1_Load(System.Object sender, System.EventArgs e)
    	{
    		rc = new ResizeableControl(pbDemo);
    
    	}
    	public Form1()
    	{
    		Load += Form1_Load;
    	}
    
    }
