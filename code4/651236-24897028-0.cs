            FileStream fs = new FileStream("D:\\niit\\deep.docx", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Console.WriteLine(str);
            Console.ReadLine();
            
        }
