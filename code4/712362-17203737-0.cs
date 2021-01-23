     private async Task<Cat> GetCatAsync()
            {
                Cat cat = new Cat(); ;
                await Task.Run(() =>
                {
                    //Use WCF to get some data from a service
                    var res = GetGoogleSearchHTML("cat").Result;
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        cat.catName = sr.ReadToEnd();
                    }
                });
    
                return cat;
            }
    
            public async Task<WebResponse> GetGoogleSearchHTML(string type)
            {
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create(String.Format("http://www.google.com/search?noj=1&site=cat&source=hp&q={0}&oq=search",type));
                System.Net.WebResponse response = await request.GetResponseAsync();
                return response;
            }
    
            public class Dog {
                public string dogName { get; set; }
                }
    
    
            public class Pig
            {
                public string pigName { get; set; }
            }
    
    
            public class Cat
            {
                public string catName { get; set; }
            }
    
    
            private async Task<Dog> GetDogAsync()
            {
                Dog dog = new Dog(); 
    
                await Task.Run(() =>
                {
                    WebResponse res = GetGoogleSearchHTML("dog").Result;
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        dog.dogName = sr.ReadToEnd();
                    }
                    //Use WCF to get some data from a service
                });
    
                return dog;
            }
    
            private async Task<Pig> GetPigAsync()
            {
                Pig pig = new Pig(); ;
    
                await Task.Run(() =>
                {
                    var res = GetGoogleSearchHTML("pig").Result;
                    using(StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        pig.pigName = sr.ReadToEnd();
                    }
                    //Use WCF to get some data from a service
                });
    
                return pig;
            }
    
            public async void GetTypes()
            {
             List<Task> taskList = new List<Task>() {  };
    
    
                 Task<Cat> catAsync = GetCatAsync();
                 Task<Dog> dogAsync = GetDogAsync();
                 Task<Pig> pigAsync = GetPigAsync();
    
             await Task.WhenAll(catAsync , dogAsync , pigAsync );
            
            var cat= catAsync.Result;
            var dog= dogAsync.Result;
            var pig= pigAsync.Result;
            }
    public WebApiResult GetResponses()
    {
    
    GetTypes();
    
    return new WebApiResult();
    
    }
