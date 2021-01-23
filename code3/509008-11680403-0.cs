     public static bool SocketConnected(Socket s)
            {
                if (!s.Connected) return false;
                bool part1 = s.Poll(1000, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 & part2)
                    return false;
                return true;
            }
