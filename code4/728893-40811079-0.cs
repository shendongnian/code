    // PrintedPage is a value type
    //this is a struct
    struct PrintedPage
    {
        public string Text;
    }
    
    // WebPage is a reference type
    class WebPage
    {
        public string Text;
    }
    
    struct SampleClass
    {
        public string Text { get; set; }
       	public override string ToString() { return Text; }
    }
    
    void Main()
    {
            // First look at value type behaviour
            PrintedPage originalPrintedPage = new PrintedPage();
            originalPrintedPage.Text = "Original printed text";
            
            // Copy all the information
            PrintedPage copyOfPrintedPage = originalPrintedPage;
            
            // Change the new copy
            copyOfPrintedPage.Text = "Changed printed text";
            
            // Write out the contents of the original page.
            // Output=Original printed text
            Console.WriteLine ("originalPrintedPage={0}",
                               originalPrintedPage.Text);
            
            
           //-------------------------------------------------------------------
            // Now look at reference type behaviour
            WebPage originalWebPage = new WebPage();
            originalWebPage.Text = "Original web text";
            
            // Copy just the URL
            WebPage copyOfWebPage = originalWebPage;
            // Change the page via the new copy of the URL
            copyOfWebPage.Text = "Changed web text";
            
            // Write out the contents of the page
            // Output=Changed web text
            Console.WriteLine ("originalWebPage={0}",
                               originalWebPage.Text);
            
            // Now change the copied URL variable to look at
            // a different web page completely
            copyOfWebPage = new WebPage();
            copyOfWebPage.Text = "Changed web page again";
    		
    		 Console.WriteLine ("originalWebPage={0}",
                               originalWebPage.Text);
            Console.WriteLine ("copyOfWebPage={0}",
                               copyOfWebPage.Text);
            
    		
           //-------------------------------------------------------------------
    		//string are reference type too
    	     object obj1 = "OriginalString"; // create a new string; assign obj1 the reference to that new string "OriginalString"
             object obj2 = obj1;// copy the reference from obj1 and assign into obj2; obj2 now refers to // the same string instance
             obj1 = "NotOriginalString";// create a new string and assign that new reference to obj1; note we haven't // changed obj2 - that still points to the original string, "OriginalString"
    	    /*	 When you do obj1 = "NewString"; it actually holds a new reference, to another memory location, not the same location you gave to obj2 before. 
    		   IMP -  When you change the content of the location obj1, you will get the same change in obj2.
            */
             Console.WriteLine(obj1 + "   " + obj2);
    		 
           //-------------------------------------------------------------------
    		 object onj11 = 2; 
             object obj12 = onj11;
             onj11 = 3; //you assigned boj11 to a new reference but obj12 reference did not change
             Console.WriteLine(onj11 + "   " + obj12);
    		
           //------------------------------------------------------------------- 	 
    		 /*look below - it's possible for object to "reference" a value-type by the power of boxing. The box is a reference-type wrapper around a value, to which the object variable refers.*/
    		 int i = 2; //int is value type
             object j = i; //variable j is a reference to a box containing the value of i- but it's not i
             i = 3;	 
             Console.WriteLine(i + "   " + j);		 
    	
           //-------------------------------------------------------------------
    		var x = new SampleClass{ Text = "Hello" };
            object o = x;
            x.Text = "World";
            Console.WriteLine(x.Text + "   " + o);
    	 
    	   //-------------------------------------------------------------------
    		SampleClass x1 = new SampleClass{ Text = "Hello" }; //sample class is of type struct which is value type; it is was of type class then the data would be copied over and result would be World World
            SampleClass o1 = x1;
            o1.Text = "World";
            Console.WriteLine(x + "   " + o);
        }
