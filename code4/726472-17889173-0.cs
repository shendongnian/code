    public class data
    {
        public string date, time,mag;
        public double lat, lon, depth;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            string dt;
            List<data> gd = new List<data>();
            using (StreamReader sr = new StreamReader("E:\\op.html"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string [] arr = line.Split(new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);
                    while (sr.Peek() > 0)
                    {
                        string[] s = new string[] { " " };
                        char[] c = new char[] { ' ' };
                        str = sr.ReadLine();
                        arr = str.Split(c);
                        data d = new data();
                        d.date = arr[0];
                        d.time = arr[1];
                       
                        d.lon =Convert.ToDouble(arr[3]);
                        d.depth = Convert.ToDouble (arr[4]);
                        d.mag = arr[8];
                        //                    File.WriteAllText("E:\\abc.txt",d.date);
                        Console.WriteLine(d.date);
                        Console.WriteLine(d.time);
                        //Console.WriteLine(d.lat);
                        Console.WriteLine(d.lon);
                        Console.WriteLine(d.depth);
                        Console.WriteLine(d.mag);
                        int x = arr[0].Length;
                        Console.WriteLine(x);
                        Console.ReadKey();
                    }
