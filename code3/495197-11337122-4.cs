    	private string PrivateField = "private";
    }
    
    Test t = new Test();
    var publicFieldInfo = typeof(Test).GetField("PrivateField", BindingFlags.Instance | BindingFlags.NonPublic);
    Console.WriteLine(publicFieldInfo.GetValue(t)); //outputs "private"
