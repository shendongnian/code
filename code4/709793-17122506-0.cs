    public void Shuffle(System.Collections.ArrayList elements)
        {
            int temp;
            Random randomNumber=new Random();
            for (int n = elements.Count; n > 1; )
            {
                int k = randomNumber.Next(n); //returning random number less than the value of 'n'
                --n; //decrease radom number generation area by 1 
                //swap the last and selected values
                temp = Convert.ToInt16(elements[n]);
                elements[n] = elements[k];
                elemetns[k] = temp;
            }
        }
