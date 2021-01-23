    public class Pail
    {
        public string milk;
        public string water;
        public string butter;
        public string beer;
        
       private bool everythingEmpty = true;
        public Pail(int i)
        {
                switch(i)
                {
                    case 1:
                    {
                        milk = "This pail has milk";
                        everythingEmpty = false;
                    }
                    break;
                    case 2:
                    {
                        butter = "This pail has butter";
                        everythingEmpty = false;
                    }
                    break;
                    case 3:
                    {
                        water = "This pail has water";
                        everythingEmpty = false;
                    }
                    break;
                    case 4:
                    {
                        beer = "This pail has beer";
                        everythingEmpty = false;
                    }
                    break;
                }
        }
    
        public void WriteToStream(StreamWriter SW)
        {
               if (everythingEmpty)
               {
                   Console.Writeline("oops");
                   return;
               }
               WriteToStream(milk, SW);
               WriteToStream(butter, SW);
               WriteToStream(beer, SW);
               WriteToStream(water, SW);
        }
        public static void WriteToStream(string content, StreamWriter SW)
        {
                    if (!content.IsNullOrEmpty())
                    {
                        SW.WriteLine(content);
                    }
        }
    }
    
    
    
    public class AddToPail()
    {
        private List<pail> _pailList = new List<pail>();
        PSVM(String[] args)
        {
            for(int i = 0; i < 200; i++)
            {
                pail newPail = new Pail(i);
                _pailList.Add(newPail);
            }
            foreach (pail thisPail in _pailList)
            {
                using (StreamWriter SW = new StreamWriter(@"C:\pail.txt")
                {
                    thisPail.WriteToStream(SW);
                }
            }
        }
    }
