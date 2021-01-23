    public class Person
    {
        public int id { set; get; }
        public string familyName { set; get; }
        public string givenName { set; get; }
        public string middleNames { set; get; }
        public string dateOfBirth { set; get; }
        public string dateOfDeath { set; get; }
        public string placeOfBirth { set; get; }
        public double height { set; get; }
        public string twitterId { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string newText = "{";
            System.IO.StreamReader file =  new System.IO.StreamReader("c:\\test.txt");
            
            while ((line = file.ReadLine()) != null)
            {
                newText += line.Insert(line.IndexOf("=") + 1, "\"") + "\",";
                
            }
            file.Close();
            newText = newText.Remove(newText.Length -1);
            newText = newText.Replace("=", ":");
            newText += "}";
            Person Person = JsonConvert.DeserializeObject<Person>(newText);
           
            Console.ReadLine();
        }
    }
