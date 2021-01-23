    static async Task<String> sayHelloAsync(){
                
           await Task.Delay(1000);
           return "hello world";
    
    }
    
    static void main(string[] args){
    
          var data = sayHelloAsync();
          //implicitly waits for the result and makes synchronous call. 
          //no need for Console.ReadKey()
          Console.Write(data.Result);
          //synchronous call .. same as previous one
          Console.Write(sayHelloAsync().GetAwaiter().GetResult());
    }
