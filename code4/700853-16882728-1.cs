    private List<MyClass> listMyClass = new List<MyClass>();
    
    private void btnPlay_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < listBoxFiles.Items.Count; i++)
        {
            myClass classObj = new MyClass();
    	    listMyClass.Add(classObj); //store the reference
            classObj.play...
        }
    }
    
    private void btnStop_Click(object sender, EventArgs e)
    {
       foreach(var obj in listMyClass)
       {
    	obj.play = false; //do wahatever you want to do with your MyClass object
       }       
    
    }
