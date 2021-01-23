    public void go()
        {
            Dispatcher.BeginInvoke(new Action(()=>{
            while (true)
            {
                string acc = "";
                string proxy = "";
                if (checkBox1.IsChecked == true || checkBox2.IsChecked == true)
                {
                    if (checkBox1.IsChecked == true)
                        Proxy.type = "http";
                    else if (checkBox2.IsChecked == true)
                        Proxy.type = "socks5";
                    else
                        Proxy.type = "none";
                    proxy = rand_proxy();
                }
    }), null);
    }
