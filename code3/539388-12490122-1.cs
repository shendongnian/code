    string userName = "Test";
    string userSurname = "Test2";
    Console.WriteLine("Hi there, {0} {1}!", userName, userSurname);
    Console.WriteLine(string.Concat(new string[]
    {
    	"Hi there, ",
    	userName,
    	" ",
    	userSurname,
    	"!"
    }));
