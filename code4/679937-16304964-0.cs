    namespace EnumTest
    {
        public enum enumRole : byte { projMgr = 2, docAdmin = 3, dataAdmin = 4, sysAdmin = 9, userAdmin = 5 };
        class Program
        {
            static void Main(string[] args)
            {
                enumRole myrole = enumRole.docAdmin;
                if (myrole == enumRole.docAdmin) Console.WriteLine("I am docAdmin");
                // i use the key to save to SQL and restore  
                // in SQL have a fk table to match the enum
                Console.WriteLine((byte)myrole);
                myrole = (enumRole)9;
                Console.WriteLine(myrole.ToString() + " " + ((byte)myrole).ToString());
                Console.ReadLine();
            }
        }
    }
