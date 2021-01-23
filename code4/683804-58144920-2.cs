csharp
var requestUri = new Uri("http://UrlOfTheApi");
using (var streamToPost = new MemoryStream("C:\temp.txt"))
using (var fileStreamContent = new StreamContent(streamToPost))
using (var httpClientHandler = new HttpClientHandler() { UseDefaultCredentials = true })
using (var httpClient = new HttpClient(httpClientHandler, true))
using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri))
using (var formDataContent = new MultipartFormDataContent())
{
	formDataContent.Add(fileStreamContent, "myFile", "temp.txt");
	requestMessage.Content = formDataContent;
	var response = httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
	
	if (response.IsSuccessStatusCode)
	{
		// File upload was successfull
	}
	else
	{
		var erroResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
		throw new Exception("Error on the server : " + erroResult);
	}
}
You need below namespaces at the top of your C# file:
csharp
using System;
using System.Net;
using System.IO;
using System.Net.Http;
P.S. Sorry about so many using blocks(IDisposable pattern) in my code. Unfortunately, the syntax of using construct of C# doesn't support initializing multiple variables in single statement.
