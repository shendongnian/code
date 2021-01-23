    var csv = new List<string[]>(); // or, List<YourClass>
    var lines = System.IO.File.ReadAllLines(@"C:\file.txt");
    foreach (string line in lines)
        csv.Add(line.Split(',')); // or, populate YourClass          
    string json = new 
        System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv);
