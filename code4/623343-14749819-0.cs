    static void Main(string[] args){
        if (args.Length == 2)
        {
            if (args[0] == "encrypt")
            {
                Console.WriteLine(encrypt(args[1]));
            } else if(args[0] == "decrypt"){
                Console.WriteLine(decrypt(args[1]));
            }
        }
    }
