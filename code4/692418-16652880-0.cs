    using System.Linq;
    // ...
    var usernames = File.ReadAllLines(@"C:\log.txt");
    if (usernames.Contains("Username : " + Username.Text)) {
        // Username exists
