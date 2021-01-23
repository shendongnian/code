        interface IAnimal
        {
            string diary(string notes, int sleephours);   
        }
    
        class Dogs:IAnimal
        {        
            
    virtual public string voice()
            {
                string v = "Hao Hao"; return v;
            } 
            string IAnimal.diary(string notes,int sleephours)
            {
                return notes + sleep.ToString() + " hours";
            }
                   
        }
    
        class Cats:Dogs
        {
            public override string voice()
            {
                string v = "Miao Miao"; return v;
            }
        }
