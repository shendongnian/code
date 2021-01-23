    //your class will be 
    class MyClass
    {
         float weight {get;set;}
         string Title {get;set;}
         float price {get;set;}
         string message {get;set;} 
    }
    
       //select new will be     
        select new MyClass
        {
            Title =  p.Product.Title,
            price =  p.Product.Price,
            weight = 0,
            message = string.empty
        }
