    static void main(string[] args){
      sayHelloAsync().Wait();
      Console.Read();
    }
    
    static async Task sayHelloAsync(){          
      await Task.Delay(1000);
      Console.Write( "hello world");
    
    }
