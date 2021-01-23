    internal class InputMessage
    {
         public string RecordID { get; set;}
         public string Data { get; set;}
    }
     string str = "someId=00000-000-0000-000000;someotherId=123456789;someIdentifier=3030";
        string [] arr = str.Split(';');
	List<InputMessage> inputMessages = new List<InputMessage>();
	for(int i=0; i < arr.Length; i++)
	{
	       string []arrItem = arr[i].Split('=');
		inputMessages.Add(new InputMessage{ RecordID = arrItem[0], Data = arrItem[1]});			
	}
	
