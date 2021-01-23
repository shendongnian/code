        using System;
    using Newtonsoft.Json;
    
    namespace {
    
        [Serializable]
         class  {
    
            public int Result;
            public string Message;
            public Extras Extras;
    
            //Empty Constructor
            public (){}
    
            public string Serialize()
            {
                return JsonConvert.SerializeObject(this);
            }
            public static  FromJson(string json)
            {
                return JsonConvert.DeserializeObject<>(json);
            }
        }
    
    
        [Serializable]
         class 5 {
    
            public string JobName;
            public string JobMaxIdleTime;
            public string JobMaxTime;
    
            //Empty Constructor
            public 5(){}
    
        }
    
    
        [Serializable]
         class Jobs {
    
            public 5 5;
    
            //Empty Constructor
            public Jobs(){}
    
        }
    
    
        [Serializable]
         class Customers {
    
            public string 8;
    
            //Empty Constructor
            public Customers(){}
    
        }
    
    
        [Serializable]
         class Extras {
    
            public Jobs Jobs;
            public Customers Customers;
    
            //Empty Constructor
            public Extras(){}
    
        }
    
    }
