    class Program
    {
        static void Main(string[] args)
        {
            int totalCats = 0;
            HashSet<Cat> allCats = new HashSet<Cat>();
            List<Cat> tempCats = new List<Cat>();
            //put 10 cats in
            for (int i = 0; i < 10; i++)
            {
                tempCats.Add(new Cat(i));
                totalCats += 1;
            }
            //add the cats to the final hashset & empty the temp list
            allCats.UnionWith(tempCats);
            tempCats = new List<Cat>();
            //create 10 identical cats
            for (int i = 0; i < 10; i++)
            {
                tempCats.Add(new Cat(i));
                totalCats += 1;
            }
            //join them again
            allCats.UnionWith(tempCats);
            //print the result
            Console.WriteLine("Total cats: " + totalCats);
            foreach (Cat curCat in allCats)
            {
                Console.WriteLine(curCat.CatNumber);
            }
        }
    }
    public class Cat
    {
        public int CatNumber { get; set; }
        public Cat(int catNum)
        {
            CatNumber = catNum;
        }
    }
