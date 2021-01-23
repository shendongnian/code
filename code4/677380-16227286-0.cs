        public static void ReadingMethod()
        {
    
            FileStream fsr = new FileStream("fileone.txt", FileMode.Open, FileAccess.Read);     
            StreamReader Sr = new StreamReader(fsr);       
            string line = Sr.ReadLine();
            Console.WriteLine("--Reading The File--" + Environment.NewLine + line + Environment.NewLine);
            Console.ReadLine();
    
            Sr.Close();
            fsr.Close();
        }
