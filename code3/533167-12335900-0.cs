            if (e.Errno == ETERM)
            {
                //Catch a termination error. 
                Debug.WriteLine("Terminated! 1");
                client.Close();
                return;
            }
  
