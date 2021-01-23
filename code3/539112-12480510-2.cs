      for (int i = 1; i <= 36; i++)
        {
            var iString = i.ToString();
            if(iString.Length == 1)
            {
                iString = iString.PadLeft(2,'0'); //RIGHT HERE!!!
            }
            Response.Write("Test: " + iString);
        }
