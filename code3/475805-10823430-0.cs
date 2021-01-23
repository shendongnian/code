    using System.Reactive.Linq;
        private void RealForm_Load(object sender, EventArgs e)
        {
            var g = new Splash();
            // place in this delegate the call to your time consuming operation
            var timeConsumingOperation = Observable.Start(() => Thread.Sleep(5000));
            timeConsumingOperation.ObserveOn(this).Subscribe(x =>
            {
                g.Close();
                this.Visible = true;
            });
            this.Visible = false;
            g.ShowDialog();
        }
