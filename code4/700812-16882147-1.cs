       var newContent = new StringBuilder();
            string[] fileLineString = File.ReadAllLines(Server.MapPath("~") + "/App_Data/Users.txt");
    
            for (int i = 0; i < fileLineString.Length; i++)
            {
                string[] userPasswordPair = fileLineString[i].Split(' ');
    
                if (Session["user"].ToString() == userPasswordPair[0])
                {
                    fileLineString[i] = fileLineString[i].Replace(userPasswordPair[1], newPasswordTextBox.Text);
                }
    
                newContent.Append(fileLineString[i]);
            }
    
            File.WriteAllText((Server.MapPath("~") + "/App_Data/Users.txt", newContent.ToString());
