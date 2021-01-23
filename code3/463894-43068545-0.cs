    public String Author
        {
            get { return author; } 
            set 
            {
                if (value.Equals(""))
                    Console.WriteLine();
                else
                    author = value; 
            }
        }
