  	Sub Main()
		Dim client = New System.Net.Sockets.TcpClient("hostname", 143)
		Using s = client.GetStream(), 
			reader = New StreamReader(s),
			writer = New StreamWriter(s)
			
				Dim send As Action(Of String) = Sub(command) 
					writer.WriteLine(command)
					writer.Flush()
				End Sub
	
				Dim recieve As Func(Of String, String) = Function(tag) 
					Dim response As String
					Dim str As String = ""
					response = reader.ReadLine()
					While response IsNot Nothing
						str += response
						If response.StartsWith(tag, StringComparison.Ordinal) Then
							Exit While
						End If
						response = reader.ReadLine()
					End While
					Return str
				End Function
	
				send("a login username password")
				recieve("a")
				send("b select inbox")
				Console.WriteLine(Regex.Match(recieve("b"), "\d* RECENT").Value)
				send("c logout")
				recieve("c")
		
		End Using
	End Sub
----------
    void Main()
    {
    	var client = new System.Net.Sockets.TcpClient("hostname", 143);
    	using (var s = client.GetStream())
    	using (var reader = new StreamReader(s))
    	using (var writer = new StreamWriter(s))
    	{
    		Action<string> send = (command) => 
    		{
    			writer.WriteLine(command);
    			writer.Flush();
    		};
    		
    		Func<String, String> recieve = (tag) =>
    		{
    			string response;
    			string str="";
    			while ((response = reader.ReadLine()) != null ) 
    			{
    				str+=response;
    				if (response.StartsWith(tag, StringComparison.Ordinal))
    					break;
    			}
    			return str;
    		};
    		
    		send("a login username password");
    		recieve("a");
    		send("b select inbox");
    		Console.WriteLine(Regex.Match(recieve("b"), @"\d* RECENT").Value);
    		send("c logout");
    		recieve("c");
    	}
    }
