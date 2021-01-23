    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    struct Person
    {
    	public int ID;
    	public decimal MonthlySalary;
    	public long LastReviewDate;
    	[VBFixedString(15)]
    	public string FirstName;
    	[VBFixedString(15)]
    	public string LastName;
    	[VBFixedString(15)]
    	public string Title;
    	[VBFixedString(150)]
    	public string ReviewComments;
    }
