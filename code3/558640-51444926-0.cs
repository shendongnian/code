    static void Main(string[] args){
       SomeTaskManager someTaskManager  = new SomeTaskManager();
       Task<List<String>> task = Task.Run(() => marginaleNotesGenerationTask.Execute());
       task.Wait();
       List<String> r = task.Result;
    } 
    public class SomeTaskManager
    {
        public async Task<List<String>> Execute() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4000/");     
            client.DefaultRequestHeaders.Accept.Clear();           
            HttpContent httpContent = new StringContent(jsonEnvellope, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = await client.PostAsync("", httpContent);
            if (httpResponse.Content != null)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                dynamic answer = JsonConvert.DeserializeObject(responseContent);
                summaries = answer[0].ToObject<List<String>>();
            }
        } 
    }
