    public class ServiceWrapper 
    { 
        WebClient wc {get;set;}
        public ServiceWrapper() 
        { 
            wc = new WebClient(); 
            wc.OpenReadAsync(new Uri(UriOfEvent)); 
            wc.OpenReadCompleted += ServerEventOccurs; 
        } 
     
        private void ServerEventOccurs(object sender, OpenReadCompletedEventArgs args) 
        { 
            using (var sr = new StreamReader(args.Result)) 
            { 
                var message = ParseStream(sr); 
                RaiseServerEventOccurred(message); 
            } 
     
            wc = new WebClient(); 
            wc.OpenReadAsync(new Uri(UriOfEvent)); 
        }  
     
        //usual code for declaring and raising ServerEventOccurred event 
    } 
