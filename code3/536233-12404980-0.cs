    var email = emailLoginTextBox.Text;
    var password = passwordLoginTextBox.Password;
    var client = new RestClient("http://www.mywebsite.com");
    var request = new RestRequest("signin", Method.POST);
    
    request.AddParameter("em", email);
    request.AddParameter("pw", password);
    var result = "";
    
    client.ExecuteAsync(request, (response) =>
                                                 {
                                                     result = response.Content;
                                                     Console.Write(result);
                                                 }
                    );
