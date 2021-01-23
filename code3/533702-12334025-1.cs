            string path = Directory.GetCurrentDirectory() + "\\test.txt";
            string str;
            using (StreamReader sreader = new StreamReader(path)) {
                str = sreader.ReadToEnd();
            }
            
            File.Delete(path);
            using (StreamWriter swriter = new StreamWriter(path, false))
            {
                str = "example text" + Environment.NewLine + str;
                swriter.Write(str);
            }
