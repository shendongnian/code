     public class Shuffler
     {
        Random randomNumber;
        public Shuffler()
        {
            randomNumber = new Random();
        }
        /// <summary>
        /// Shuffling the elements of Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public void Shuffle<T>(IList<T> array)
        {
            for (int n = array.Count; n > 1; )
            {
                int k = randomNumber.Next(n); //returning random number less than the value of 'n'
                --n; //decrease radom number generation area by 1 
                 //swap the last and selected values
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
     }
