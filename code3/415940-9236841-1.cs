                try
                {
                    if(admObj.Key == "Title")
                    {
                        encodedValue = admObj.Value.ToString();
                    }else
                    {
                        encodedValue = admObj.Value[0].ToString();
                    }
                }
                catch (Exception)
                {
                    encodedValue = admObj.Value.ToString();                   
                }
