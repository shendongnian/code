    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
    	int[] indx = {
    		1,
    		2,
    		3,
    		4,
    		5,
    		10,
    		50,
    		100,
    		500,
    		1000
    		// initialize array of integers 
    	};
    	string[] row = {
    		"I",
    		"II",
    		"III",
    		"IV",
    		"V",
    		"X",
    		"L",
    		"C",
    		"D",
    		"M"
    		//Carasponding roman letters in for the numbers in the array
    	};
    		// integer to indicate the position index for link two arrays 
    	int limit = 9;
    		//string to store output
    	string output = "";
    	private void Button1_Click(System.Object sender, System.EventArgs e)
    	{
    		int num = 0;
    		// stores the input 
    		output = "";
    		// clear output before processing
    		num = Convert.ToInt32(txt1.Text);
    		// get integer value from the textbox
    		//Loop until the value became 0
    		while (num > 0) {
    			num = find(num);
    			//call function for processing
    		}
    		txt2.Text = output;
    		// display the output in text2
    	}
    	public int find(int Num)
    	{
    		int i = 0;
    		// loop variable initialized with 0
    		//Loop until the indx(i).value greater than or equal to num
    		while (indx(i) <= Num) {
    			i += 1;
    		}
    		// detemine the value of limit depends on the itetration
    		if (i != 0) {
    			limit = i - 1;
    		} else {
    			limit = 0;
    		}
    		output = output + row(limit);
    		//row(limit) is appended with the output
    		Num = Num - indx(limit);
    		// calculate next num value
    		return Num;
    		//return num value for next itetration 
    	}
    }
