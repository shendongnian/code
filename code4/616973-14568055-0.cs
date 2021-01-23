    namespace PasswordGenerator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Your new password is : " + CreateRandomPassword(8));
                Console.ReadLine();
            }
            private static string CreateRandomPassword(int passwordLength)
            {
                string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
                char[] chars = new char[passwordLength];
                Random random = new Random();
    
                bool containsNum = false;
                do {
                    for (int i = 0; i < passwordLength; i++)
                    {
                        chars[i] = allowedChars[random.Next(0, allowedChars.Length)];
                        if(Char.IsDigit(chars[i])){
                            containsNum = true;
                        }
                    }
                } while(!containsNum);
                
                return new string(chars);
            }
        }
    }
