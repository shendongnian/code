    public string DrinkAbeerAndSingTheSong()  
    {  
        CurrentBeer = beerCollection.Length - 1;  //take 1 off, remember the array index is zero based   
        //StringBuilder sb = new StringBuilder();
        do
        {
            beerCollection[CurrentBeer].IsFull = false;
            //sb.AddLine(CurrentBeer + "... beers on the wall");
            //Console.Writeline(CurrentBeer + "... beers on the wall");
            CurrentBeer--;
        } while (CurrentBeer > 0);
        return CurrentBeer + "... beers on the wall";
        //sb.AddLine(CurrentBeer + "... beers on the wall");  //don't forget the last line of the song
        //return sb.ToString();
    }
