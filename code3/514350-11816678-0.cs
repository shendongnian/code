    private void WriteUserToFile(User user, string path)
    {
        using(var sw = new StreamWriter(path, true))
        {
            sw.WriteLine(user.Name + ";" + user.Age);
        }
    }
