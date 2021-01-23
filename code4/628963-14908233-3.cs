    public string DrinkAbeerAndSingTheSong()  
    {  
        CurrentBeer = beerCollection.Length;   
        //StringBuilder sb = new StringBuilder();
        do
        {
            beerCollection[CurrentBeer].IsFull = false;
            //sb.AddLine(CurrentBeer + "... beers on the wall");
            //Console.Writeline(CurrentBeer + "... beers on the wall");
            CurrentBeer--;
        } while (CurrentBeer > 0);
        return CurrentBeer + "... beers on the wall";
        //return sb.ToString();
    }
