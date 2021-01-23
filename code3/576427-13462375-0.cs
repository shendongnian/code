    Person[] people= new Person[4];
    using(var file = System.IO.File.OpenText(_LstFilename))
    {
       int j=0;
     while (!file.EndOfStream)
        {
            String line = file.ReadLine();
    
            // ignore empty lines
            if (line.Length > 0)
            {    
    
                string[] words = line.Split(' ');
                 Person per= new Person(words[0], words[1], words[2], Convert.ToInt32(words[3]));
                
                 people[j]=per;
                 j++
                
            }
    
    }
