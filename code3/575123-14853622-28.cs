    a) **continuations**
        // continuation with ContinueWhenAll - execute the delegate, when ALL
        // tasks[] had been finished; other option is ContinueWhenAny
        Task.Factory.ContinueWhenAll( 
           tasks,
           () => {
               int answer = tasks[0].Result + tasks[1].Result;
               Console.WriteLine("The answer is {0}", answer);
           }
        );
         
      b) **nested/child tasks** 
        //StartNew - starts task immediately, parent ends whith child
        var parent = Task.Factory.StartNew
        (() => {
                  var child = Task.Factory.StartNew(() =>
                 {
                 //...
                 });
              },  
              TaskCreationOptions.AttachedToParent
        );
