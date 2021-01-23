    Console.WriteLine(DateTime.Now);
    
    //This block takes 1 second to run because all 5 tasks are running simultaneously
    {
    	var a = Task.Delay(1000);
    	var b = Task.Delay(1000);
    	var c = Task.Delay(1000);
    	var d = Task.Delay(1000);
    	var e = Task.Delay(1000);
    
    	await a;
    	await b;
    	await c;
    	await d;
    	await e;
    }
    
    Console.WriteLine(DateTime.Now);
    
    //This block takes 5 seconds to run because each "await" pauses the program until the task finishes
    {
    	await Task.Delay(1000);
    	await Task.Delay(1000);
    	await Task.Delay(1000);
    	await Task.Delay(1000);
    	await Task.Delay(1000);
    }
    Console.WriteLine(DateTime.Now);
