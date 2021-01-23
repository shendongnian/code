    public class txtedit
    {
        public string Write_txt(string textin, out String output)
        {
            output = "";
            try
            {
                using (StreamReader sr = new StreamReader(textin))
                {
                    String line = sr.ReadToEnd();
                    output = line;
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return output;
        }
    
