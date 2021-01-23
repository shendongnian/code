            klubb[] klubbar = new klubb[100]; //Skapa en vektor där varje element kan behålla flera olika variblar från klassen "klubb"
            //IF YOU REMOVE THIS STREAMREADERCODE WITH THE WHILE LOOP EVERYTHING WILL WORK FINE
            StreamReader lasa = new StreamReader("klubbar.txt");
            while (true)
            {
                string line = lasa.ReadLine();
                if (line == null)
                {
                    break;
                }
                antal++;
                Console.WriteLine(line);
               // klubbar[antal] = line;     //ADD EACH LINE IN TEXTFILE TO AN SEPAREATE INDEX IN ARRAY klubar
            }
            lasa.Close();
