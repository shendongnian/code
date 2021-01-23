    string userDataFile = Server.MapPath("~") + "/App_Data/tuitterUsers.txt";
    string[] userDataArray = File.ReadAllLines(userDataFile);
    for(int x = 0; x < userDataArray.Length; x++)
    {
        string[] info = userData[x].Split(' ');
        if(Session["Username"].ToString() == info[0])
        {
            userData[x] = string.Join(" ",  Session["UserName"].ToString(),
                                            newPasswordTextBox.Text,
                                            avatarDropDownList.SelectedValue.ToString());
            break;
        }
    }
    string fileToWrite = string.Join(Environment.NewLine, userDataArray);
    File.WriteAllText(Server.MapPath("~") + "/App_Data/tuitterUsers.txt", fileToWrite);
