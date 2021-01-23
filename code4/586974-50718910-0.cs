    System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                this.Invoke(new Action(() => 
                    Method1()));
            });
