    task.ContinueWith(t =>
        {
            var responseCode = (HttpWebResponse)t.Result;
            ReadStreamFromResponse(t.Result);
            if(responseCode.StatusCode == HttpStatusCode.OK)
            {
                webResult.ElementAt(TimerCounter).ResponseStatusCode = "Up"; //Error occurs here
                reponseCode.Close();
            }
            webResult.ElementAt(TimerCounter).RequestSentTime = DateTime.Now.ToString();
            if(webResult.ElementAt(TimerCounter).SystemStatus == null)
                webResult.ElementAt(TimerCounter).SystemStatus = "";
            TimeCounter++;
         });
