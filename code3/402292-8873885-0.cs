    private static void Notify(string url, string author, string mess)
    {
        using(Toast slice = new Toast(100000, url, author, mess) { Height = 90 })
        {
            slice.ShowDialog();
        }
    }
    public void Job()
    {
        Notify("http://google.com", "username", "hi all");
    }
