    internal class Something : IDisposable {
    private Stream stream;
    
    public void SomeMethod() {
        stream.Write("nskdns");
    }
    
    public void Dispose() {
        if (stream != null) {
            stream.Close();
        }
    }
