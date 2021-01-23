        byte[] buffer = null;
        using (System.IO.FileStream stm = new System.IO.FileStream("c:\\YourFile.txt", 
                   System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
        {
        buffer = new byte[stm.Length];
        stm.Read(buffer, 0, Convert.ToInt32(stm.Length));
        }
