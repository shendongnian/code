    // Validation
        bool isValid = false;
    
        // If this is a POST request, validate and process data
            if (IsPost) {
                username = Request.Form["username"];
                password = Request.Form["password"];
                rememberMe = Request.Form["remember"].AsBool();
    
                // Attempt to login to the external authentication server
                // if(isValid)
                {
                    using (TcpClient client = new TcpClient("hosty.host.com", 110)) {
                    using (NetworkStream stream = client.GetStream()) {
                    using (StreamReader reader = new StreamReader(stream)) {
                    using (StreamWriter writer = new StreamWriter(stream)) {
                        writer.WriteLine("USER " + username );
                        writer.WriteLine("PASS " + password );
                        string response = reader.ReadLine();
                        isValid = response[ 0 ] == '+';
                        Response.Write(response);
                        writer.WriteLine("quit\n");
                    }
                    }
                    }
                    }
                }
    
                if (isValid) {
                    <text>IT WORKED---></text>
                //USER LOGGED IN/ SESSION STARTED
    
    
                } else {
                    <text>IT DIDNT WORK :( </text>
                    //USER NOT LOGGED IN, SESSION NOT STARTED
                }
            }
