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
	
				send("a login username password"): recieve("a")
				send("b select inbox"): recieve("b")
			
				send("b2 SEARCH UNSEEN")
				Dim b2response = recieve("b2")
				Dim items = Regex.Match(b2response, "SEARCH (.*) OK").Groups(1).Value.Split(" "c)
				Console.WriteLine("Unread items: " + items.Count().ToString())
			
				send("c logout"): recieve("c")
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
    		
    		send("a login username password"); recieve("a");
			send("b select inbox"); recieve("b");
			
			send("b2 SEARCH UNSEEN");
			var b2response = recieve("b2");
			var items = Regex.Match(b2response, @"SEARCH (.*) OK").Groups[1].Value.Split(' ');
			Console.WriteLine("Unread items: " + items.Count().ToString());
		
			send("c logout"); recieve("c");
    	}
    }
