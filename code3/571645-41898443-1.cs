        if (con.State != ConnectionState.Open && conn.State != ConnectionState.Connecting) {
                con.Open();
            }
            var attempts = 0;
            while (con.State == ConnectionState.Connecting && attempts < 10) {
                attempts++;
                Thread.Sleep(500);
            }
