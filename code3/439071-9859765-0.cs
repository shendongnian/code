    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
    
    	System.DateTime dateStart;
    	System.DateTime dteFinish;
    
    	TimeSpan span;
    
    	public void KeyDown(System.Object Sender, System.Windows.Forms.KeyEventArgs e)
    	{
    		switch (e.KeyCode) {
    			case Keys.Q:
    				Label1.BackColor = Color.Green;
    				dteStart = DateAndTime.Now();
    				break;
    			case Keys.W:
    				Label2.BackColor = Color.Green;
    				break;
    			case Keys.E:
    				Label3.BackColor = Color.Green;
    				break;
    			case Keys.R:
    				Label4.BackColor = Color.Green;
    				dteFinish = DateAndTime.Now();
    				span = dteFinish.Subtract(dteStart);
    				Label5.Text = span.ToString();
    
    				break;
    		}
    
    	}
    
    
    	public void KeyUp(System.Object Sender, System.Windows.Forms.KeyEventArgs e)
    	{
    		switch (e.KeyCode) {
    			case Keys.Q:
    				Label1.BackColor = Color.Red;
    				break;
    			case Keys.W:
    				Label2.BackColor = Color.Red;
    				break;
    			case Keys.E:
    				Label3.BackColor = Color.Red;
    				break;
    			case Keys.R:
    				Label4.BackColor = Color.Red;
    				break;
    		}
    
    	}
    	public Form1()
    	{
    		KeyUp += KeyUp;
    		KeyDown += KeyDown;
    	}
    }
