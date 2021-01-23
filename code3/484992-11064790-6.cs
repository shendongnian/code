    using System.Threading.Tasks;
    ...
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.Visible = false; // optional
        this.ShowInTaskbar = false; // optional
        Task db = Task.Factory.StartNew(() => DBUpdate();
        Task.WaitAll(db); // you can have more tasks like the one above
    }
    private void DBUpdate()
    {
        // write your db code here
    }
