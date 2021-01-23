    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
    
    	public Form1()
    	{
    		DragDrop += DD;
    		DragEnter += Panel1DragEnter;
    		// This call is required by the designer.
    		InitializeComponent();
    
    		// Add any initialization after the InitializeComponent() call.
    		Panel1.AllowDrop = true;
    		AllowDrop = true;
    
    	}
    
    	private void Panel1DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
    	{
    		if (object.ReferenceEquals(sender, Panel1)) {
    			Panel1.Capture = true;
    		}
    
    		if (Panel1.Capture) {
    			if ((e.Data.GetDataPresent(DataFormats.FileDrop))) {
    				e.Effect = DragDropEffects.Copy;
    			} else {
    				e.Effect = DragDropEffects.None;
    			}
    			Panel1.Capture = true;
    		}
    
    	}
    
    	private void DD(object sender, DragEventArgs e)
    	{
    		if (Panel1.Capture) {
    			Interaction.MsgBox("dropped");
    		}
    		Panel1.Capture = false;
    	}
    
    
    }
