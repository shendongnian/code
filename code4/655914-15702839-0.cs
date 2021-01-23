    WebClient webClient = new WebClient();
            webClient.OpenReadAsync(new Uri(addy));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            
        }
        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var reader = new StreamReader(e.Result);
            results = reader.ReadToEnd();
        }
