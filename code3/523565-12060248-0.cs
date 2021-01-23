        if(!File.Exists(filename)) //No File? Create
    {
        fs = File.Create(filename);
        fs.Close();
    }
    if(File.ReadAllBytes().Lenght >= 100*1024*1024) // (100mB) File to big? Create new
    {
        string filenamebase = "myLogFile"; //Insert the base form of the log file, the same as the 1st filename without .log at the end
        if(filename.contains("-")) //Check if older log contained -x
        {
             int lognumber = Int32.Parse(filename.substring(filename.lastIndexOf("-")+1, filename.Length-4); //Get old number, Can cause exception if the last digits aren't numbers
             lognumber++; //Increment lognumber by 1
             filename = filenamebase + "-" + lognumber + ".log"; //Override filename
        }
        else 
        {
             filename = filenamebase + "-1.log"; //Override filename
        }
        fs = File.Create(filename);
        fs.Close();
    }
