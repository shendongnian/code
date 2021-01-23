     public void AddCustomer(string sUser)
            {
                string cAddText = "<STRONG>" + sUser + "</STRONG>";
                if (CheckUser(sUser)==false)
                {
                    cArray.Add(cAddText);
                }
              
                if (cArray.Count > 200)
                {
                    cArray.RemoveRange(0, 10);
                }
            }
