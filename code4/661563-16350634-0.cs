    lock (sync) {
        while (queue.TryDequeue(out sock)) {
            if (Clients.TryGetValue(sock, out temp)) {
                if (!temp.Alive) {
                    Sockets.Remove(sock);
                    Clients.TryRemove(sock, out temp);
                } else {
                    temp.Receive();
                    Console.WriteLine("recved from thread num : " + Thread.CurrentThread.Name);
                }
            }
        }
    }
