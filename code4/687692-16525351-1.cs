    <pre>public void WaitForFileToBeReady(String path) {
        while (File.Exists(path) == false) {
            System.Threading.Sleep(50);
        }
    }</pre>
