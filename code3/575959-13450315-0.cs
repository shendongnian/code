    private void button1_Click(object sender, EventArgs e)
    {
        string user = "Steve";
        string pass = "MyPass";
        string hashedUser = GetHashedText(user);
        string hashedPass = GetHashedText(pass);
        string file = Path.Combine(Environment.GetFolderPath 
                           (Environment.SpecialFolder.ApplicationData), 
                           "MyKeys.txt");
        if (File.Exists(file))
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string recordedUser = sr.ReadLine();
                string recordedPass = sr.ReadLine();
                if (recordedUser == user && recordedPass == pass)
                    MessageBox.Show("User validated");
                else
                    MessageBox.Show("Invalid user");
            }
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.WriteLine(user);
                sw.WriteLine(pass);
            }
          
        }
    }
    private string GetHashedText(string inputData)
    { 
        byte[] tmpSource;
        byte[] tmpData;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
        tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        return Convert.ToBase64String(tmpData);
    }
    
