    public void download()
    {
        WebClient myWebClient = new WebClient();
        myWebClient.DownloadFile(Files.alutDLL, "alut.dll");
        myWebClient.DownloadFile(Files.BlackBoxDLL, "BlackBox.dll");
        myWebClient.DownloadFile(Files.DevILDLL, "DevIL.dll");
        myWebClient.DownloadFile(Files.fltkdllDLL, "fltkdll.dll");
        myWebClient.DownloadFile(Files.glut32DLL, "glut32.dll");
    }
