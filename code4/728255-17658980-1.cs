    double lowest_price =  list1[0].price; 
            foreach(Cars a in list1){
            if(a.price <= lowest_price){
                lowest_price = a.price;
                Console.WriteLine(a.price);
                }
            }//end of loop
