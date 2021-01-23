    var users = File.ReadAllLines("data.txt")
                    .Select(line => User.Parse(line))
                    .ToDictionary(u => u.Id);
    var user = users[127];
    string name = user.Name; // STARK
    Console.WriteLine(user); // 00127 STARK USA
   
