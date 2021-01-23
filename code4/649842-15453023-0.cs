    FileStream fs = null;
    StreamWriter fw = null;
    try
    {
        fs= new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/textme.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        fw = new StreamWriter(fs);
        fw.Write("sadadasdsadsadsadas");
    
        for (int i = 0; i < AnimalShelter.AnimalList.Count; i++)
        {
            fw.WriteLine("<chipNr>" + AnimalShelter.AnimalList[i].ChipRegistrationNumber + "<chipNr>");
            Console.WriteLine("<chipNr>" + AnimalShelter.AnimalList[i].ChipRegistrationNumber + "<chipNr>");
    
        }
        fw.Flush();  // Added
    }
    catch(IOException)
    {
        MessageBox.Show("ERROR THROWN");
    }
    finally
    {
        if (fs!= null) fs.Close();
        //  if (fw != null) fw.Close();
    }
