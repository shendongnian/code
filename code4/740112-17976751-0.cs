    static void Main(string[] args)
    {
        using (StreamReader myReader = null)
        {
        try
        {
            myReader = new StreamReader("c:\\j\\MyFile1.txt");
    
            string line = "";
    
            while (line != null)
            {
                line = myReader.ReadLine();
                Console.WriteLine(line);
            }
    
            //myReader.Close();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("sorry file not found! {0}", e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("You have given the wrong path for the file! {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Sorry you typed in a wrong file name! {0}", e.Message);
        }
        finally
        { 
            myReader.Close();
        }
    }
        Console.ReadLine();
    }
