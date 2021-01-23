    public class Test
    {
        public string Name;
    	public int Age;
    	public DateTime Since;
    }
    	
    void Main()
    {
        var tests = new Test[] {
    		new Test(){Name="Dude", Age=23, Since = new DateTime(2000,2,3)},
    		new Test(){Name="Guy", Age=29, Since = new DateTime(1999,3,4)},
    		new Test(){Name="Man", Age=34, Since = new DateTime(2008,11,5)},
    		new Test(){Name="Gentleman", Age=40, Since = new DateTime(2006,7,6)}
    	};
        //up until here, all code was just test preparation. 
        //Here's the actual problem solving:
        string fieldToOrderBy = "Since"; //just replace this to change order
    	FieldInfo myf = typeof(Test).GetField(fieldToOrderBy);
    	tests.OrderBy(t=>myf.GetValue(t)).Dump(); 
        //the Dump() is because I ran this in LinqPad. 
        //Replace it by your favaorite way of inspecting an IEnumerable
    }
    
    
