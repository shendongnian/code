        if (chkUserResume.Length == 0)
        {
            Response.Write("nothing is inside the folder");
        }
        else
        {
            foreach (string name in chkUserResume)
            {
                Response.Write(name + " is exist");
            }
        }
