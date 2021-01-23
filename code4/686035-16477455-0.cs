           String s = "Staaack";
            Console.WriteLine(s);
            while (Regex.Match(s,"St[O]*([a]{1})[a]*ck").Success){
                s = Regex.Replace(s,"(St[O]*)([a]{1})([a]*ck)", "$1O$3");
                Console.WriteLine(s);
            }
            Console.WriteLine(s);
            
            Console.ReadLine(); 
