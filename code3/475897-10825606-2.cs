    var a = Observable.Start(() => Thread.Sleep(8000)).StartAsync(CancellationToken.None);
    var b = Observable.Start(() => Thread.Sleep(15000)).StartAsync(CancellationToken.None);
    var c = Observable.Start(() => Thread.Sleep(3000)).StartAsync(CancellationToken.None);
    Manager.Add("a", a.ObserveOn(this).Subscribe(x => MessageBox.Show("a done")));
    Manager.Add("b", b.ObserveOn(this).Subscribe(x => MessageBox.Show("b done")));
    Manager.Add("c", c.ObserveOn(this).Subscribe(x => MessageBox.Show("c done")));
    private void button1_Click(object sender, EventArgs e)
    {
        Manager.Cancel("b");
    }
