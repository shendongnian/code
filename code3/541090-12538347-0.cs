            int l=0; 
            string s; 
            Console.WriteLine("Enter Paragraph: "); 
            s = Console.ReadLine(); 
            
            l = s.Replace(" ", String.Empty).Length; 
            Console.WriteLine("Your Paragraph Length is: " + l); 
            Console.ReadLine();
