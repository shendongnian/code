        if (conn.State != ConnectionState.Open && conn.State != ConnectionState.Connecting) {
                conn.Open();
            }
            var attempts = 0;
            while (conn.State == ConnectionState.Connecting && attempts < 10) {
                attempts++;
                Thread.Sleep(500);
            }
